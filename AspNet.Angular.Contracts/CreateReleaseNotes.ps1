New-item releaseNotes.txt -type file -force -value $(
	"--TFS Team Project: " + "$Env:BUILD_REPOSITORY_URI" + "`r`n" + "`r`n" +
	"--TFS Build ID: " + "$Env:BUILD_BUILDNUMBER" + "`r`n" +   "`r`n" +
	"--Git Commit ID: " + "$Env:BUILD_SOURCEVERSION" + "`r`n" + "`r`n" +
	"--Git Branch Path: " + "$ENV:BUILD_SOURCEBRANCH" + "`r`n" + "`r`n" +
	"--Git Branch Name: " + "$ENV:BUILD_SOURCEBRANCHNAME" + "`r`n" + "`r`n" +
	"--Git Repo Name: " + "$ENV:BUILD_REPOSITORY_NAME")