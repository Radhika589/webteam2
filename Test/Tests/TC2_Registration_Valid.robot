*** Settings ***

Library          SeleniumLibrary
Library          DateTime
Resource         ../Resources/Webteam2keywords.robot

*** Variables ***

${url}           https://localhost:44373/
${browser}       chrome

*** Test Cases ***
Registration
    [Documentation]             Test for registering the visitor profile
    [Tags]                      Register_TC 2
    Valid Credentials

*** Keywords ***

Valid Credentials
   ${unique}       Generate Random String    12   [LETTERS]

   Open Browser     about:blank     ${browser}
   Load Page
   Verify Home
   Register Link
   Input Text                       id:FirstName    Tina
   Input Text                       id:LastName     Henrik
   Click Element                    xpath://*[@id="Email"]
   Input Text                       id:Email         ${unique}
   Input Text                       id:Password     Login@123
   Click Element                    xpath://*[@id="ConfirmPassword"]
   Input Text                       id :ConfirmPassword     Login@123
   Click Element                    xpath://*[@id="Role"]
   Sleep                            2s
   Select from List by Index        id:Role         2
   Click Button                     xpath:/html/body/div/main/div/form/div[8]/input
   Sleep                            5s
   Page Should Contain Link         xpath://*[@id="navbar_item_4"]


