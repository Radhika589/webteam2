pipeline {
    agent any
     stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Radhika589/webteam2.git'
             }
         }
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
  stage('Pack') {
   steps {
    bat 'dotnet pack --no-build --output nupkgs'
   }
  }
  stage('Robot Framework System tests with Selenium') {
            steps {
                sh 'robot -d results --variable BROWSER:headlesschrome WebTeam2Test.robot'
            }
            post {
                always {
                    script {
                          step(
                                [
                                  $class              : 'RobotPublisher',
                                  outputPath          : 'results',
                                  outputFileName      : '**/output.xml',
                                  reportFileName      : '**/report.html',
                                  logFileName         : '**/log.html',
                                  disableArchiveOutput: false,
                                  passThreshold       : 50,
                                  unstableThreshold   : 40,
                                  otherFiles          : "**/*.png,**/*.jpg",
                                ]
                          )
                    }
                }
            }
        }

        
 }
}