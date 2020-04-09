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
                sh 'robot -d results --variable BROWSER:headlesschrome Dotnet.robot'
            }
                    }

        
 }
}