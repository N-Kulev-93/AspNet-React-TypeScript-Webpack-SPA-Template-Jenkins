pipeline {
    agent any
    tools{
        nodejs('24.19.0')
    }
    stages {
        stage('Build') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master', url: 'https://github.com/N-Kulev-93/AspNet-React-TypeScript-Webpack-SPA-Template'
                sh 'docker build -t spa-template-test .'

            }

        }
        stage('Push to Harbor') {
            environment {
                DOCKER_CREDENTIALS = credentials('Harbor')
            }
            steps {
                script {
                    // Login to Harbor using credentials
                    sh "docker login -u admin -p Harbor12345 harbor.h3rk0.com"

                    // Tag the image
                    sh 'docker tag library/harbor_cicd_v2 harbor.h3rk0.com/library/harbor_cicd:v${BUILD_NUMBER}'
                    
                    // Push the image to Harbor
                    sh 'docker push harbor.h3rk0.com/library/harbor_cicd:v${BUILD_NUMBER}'
                }
            }
        }
        stage('Trigger GitHub Push') {
            steps {
                build job: 'push_image_tag_git', wait: true, parameters: [string(name: 'Build_Number_Image', value: "${BUILD_NUMBER}")]
            }
        }

    }
}
