*** Settings ***

Library           SeleniumLibrary
Library           DateTime
Resource          ../Resources/Webteam2keywords.robot
Suite Setup       Begin Web Test
Suite Teardown    End Web Test
Test Template     Invalid Login

*** Test Cases ***      username        password        val1                                               val2

Ivemail vpwd            abc              Login@123       The Email field is not a valid e-mail address.     ${Empty}
Both invalid            abc              login           The Email field is not a valid e-mail address.     ${Empty}
Emptyemail vpwd         ${Empty}         Login@1         The Email field is required.                       ${Empty}
Vemail Emptypwd         Tina@yahoo.com   ${Empty}        ${Empty}                                           The Password field is required.
Both empty              ${Empty}         ${Empty}        The Email field is required.                       The Password field is required.
Vemail Ivpwd            Tina@yahoo.com   login           Invalid Username or Password                       ${Empty}


*** Keywords ***
Invalid Login
   [Arguments]          ${username}     ${password}     ${val1}     ${val2}
   Login
   Input Email          ${username}
   Input Password       ${password}
   Click Login Button
   Login Error Message  ${val1}     ${val2}

Login Error Message
   [Arguments]            ${val1}       ${val2}
   Page Should Contain    ${val1}
   Page Should Contain    ${val2}




