pipeline {
    agent any
     stages {
                stage('Restore Packages') {
            steps {
            bat "dotnet restore"
            }
         }
  stage('Clean') {
   steps {
    bat 'dotnet clean'
   }
  }
   stage('Build') {
     steps {
    bat 'dotnet build Webteam2.sln'
     }
    }
stage('Run') {
            steps {
                bat 'START /B dotnet C:/Program Files (x86)/Jenkins/workspace/WebTeam2_pipeline/Webteam2/bin/Debug/netcoreapp3.1/Webteam2.dll'
            }
        }
  stage('UI tests') {
            steps {

                    bat 'python -m robot.run C:/Projects/webteam2/Test'
            }
        }


 }
}