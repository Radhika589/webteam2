pipeline {

    agent any

    stages {
        stage('Checkout') {
                steps {
                    checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://github.com/Radhika589/webteam2.git/']]])
                }
        }
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }
        stage('Run') {
            steps {
                bat 'START /B dotnet run'
            }
        }
        stage('Robot') {
            steps {
                    sleep 10
                    bat 'robot -d results --variable BROWSER:headlesschrome "webteam2/Test/Tests/WebTeam2Test.robot" '
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