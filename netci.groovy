import jobs.generation.Utilities

def project = GithubProject
def branch = GithubBranchName
def isPR = true
def platformList = ['Windows_2016:WindowsServerCore-ltsc2016', 'Windows_2016:WindowsServerCore-1709']

platformList.each { platform ->
    def(hostOS, containerOS) = platform.tokenize(':')
    def machineLabel = 'latest-docker'

    if (containerOS == 'WindowsServerCore-1709') {
        versionList = ['3.5', '4.7.1']
    }
    else {
        versionList = ['3.5', '4.6.2', '4.7', '4.7.1']
    }

    versionList.each { version ->
        def newJobName = Utilities.getFullJobName(project, "${version}_${containerOS}", isPR)
        def versionFilter = "${version}*"

        def newJob = job(newJobName) {
            steps { 
                batchFile("powershell -NoProfile -Command .\\build-and-test.ps1 -VersionFilter \"${versionFilter}\" -OSFilter \"${containerOS}\"")
            }
        }

        if (containerOS == 'WindowsServerCore-1709') {
            newJob.with {label('windows.10.amd64.serverrs3.open')}
        }
        else {
            Utilities.setMachineAffinity(newJob, hostOS, machineLabel)
        }
        Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}")
        Utilities.addGithubPRTriggerForBranch(newJob, branch, "${containerOS} - ${version} Dockerfiles")
    }
}
