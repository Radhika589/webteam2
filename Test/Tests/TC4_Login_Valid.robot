*** Settings ***

Library          SeleniumLibrary
Library          DateTime
Resource         ../Resources/Webteam2keywords.robot
Test Setup       Begin Web Test


*** Variables ***

${url}           https://localhost:44373/
${browser}       chrome

*** Test Cases ***
Valid Login
    [Documentation]             Test for valid login functionality
    [Tags]                      Valid Login_TC 4
    Login Page
    Logout Button

