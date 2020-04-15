*** Settings ***
Library     SeleniumLibrary
Library     DateTime
Library   SeleniumLibrary

*** Variables ***

${url}           https://google.com
${browser}       chrome



*** Keywords ***
Begin Web Test
    Open Browser    about:blank         ${BROWSER}

Load Page
    Go to       ${url}

*** Test Cases ***

Login page
     Begin Web Test
     Load Page
