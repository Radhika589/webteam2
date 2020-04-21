*** Settings ***

Library           SeleniumLibrary
Library           DateTime
Resource          ../Resources/Webteam2keywords.robot
Suite Setup       Begin Web Test
Suite Teardown    End Web Test
Test Template     Invalid Registration

#V - Valid, Iv - Invalid, BV - Boundary Value

*** Test Cases ***          username        password    cnfmpwd         ${val1}                                                ${val2}
Vemail Ivpwd Ivcnfmpwd      abc@yahoo.com   1234        1234            Passwords must be at least 7 characters.               ${Empty}
Ivemail Vpwd vcnfmpwd       abc             Login@123   Login@123       The Email field is not a valid e-mail address.         ${Empty}
All invalid                 abc             logi        login           The Email field is not a valid e-mail address.         The password and confirmation password do not match.
Vemail IBVpwd IBVcnfmpwd    b@yahoo.com     Login@1234  Login@1234      Email 'b@yahoo.com' is already taken.                  User name 'b@yahoo.com' is already taken.
Vemail Vpwd Ivcnfmpwd       abc@yahoo.com   Login@123   @@@@            The password and confirmation password do not match.   The password and confirmation password do not match.
Vemail Ivpwd Vcnfmpwd       abc@yahoo.com   l           Login@123       The password and confirmation password do not match.   The password and confirmation password do not match.
Empty email                 ${Empty}        Login@123   Login@123       Email is required                                      ${Empty}
Empty pwd                   abc@yahoo.com   ${Empty}    Login@123       ${Empty}                                               The password and confirmation password do not match.
Empty cnfmpwd               abc@yahoo.com   Login@123   ${Empty}        The password and confirmation password do not match.   ${Empty}
All Empty                   ${Empty}        ${Empty}    ${Empty}        Email is required                                      Password is required


*** Keywords ***
Invalid Registration
   [Arguments]          ${username}     ${password}     ${cnfm_pwd}     ${val1}     ${val2}
   Click Register Link
   Input Email          ${username}
   Input Password       ${password}
   Input CnfmPwd        ${cnfm_pwd}
   Click Register Button
   Error Message        ${val1}     ${val2}

Error Message
   [Arguments]            ${val1}       ${val2}
   Page Should Contain    ${val1}
   Page Should Contain    ${val2}


