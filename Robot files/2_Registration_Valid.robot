*** Settings ***

Library          SeleniumLibrary
Library          DateTime
Resource         ../Resources/Webteam2keywords.robot
Library           SeleniumLibrary
Library           DateTime
Resource          ../Resources/Webteam2keywords.robot
Suite Setup       Begin Web Test

*** Variables ***

${url}           https://localhost:44373/
${browser}       chrome
#${RANDOMSTRING}      Generate Random String      4       [NUMBERS]

*** Test Cases ***

Registration
    [Documentation]             Test for valid registration
    [Tags]                      Register_TC 2

    #Set Global Variable    ${RANDOMSTRING}
    Valid Credentials

*** Keywords ***

Valid Credentials

   Click Register Link
   Generate Email
   Input Text                       id:FirstName    Tina
   Input Text                       id:LastName     Henrik
   Input Text                       id:Email        a1@email.com
   Input Text                       id:Password     Login@123
   Input Text                       id :ConfirmPassword     Login@123
   Click Element                    xpath://*[@id="Role"]
   Sleep                            2s
   Select from List by Index        id:Role         2
   Click Button                     xpath:/html/body/div/main/div/form/div[8]/input
   Sleep                            5s
   Page Should Contain Link         xpath://*[@id="navbar_item_4"]


