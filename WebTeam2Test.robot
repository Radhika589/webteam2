*** Settings ***

Library          SeleniumLibrary
Library          DateTime


*** Variables ***

${url}           https://localhost:44373/
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

