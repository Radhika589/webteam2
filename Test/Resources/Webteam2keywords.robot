*** Settings ***
Library     SeleniumLibrary
Library     DateTime


*** Variables ***
${url}           https://localhost:44373/
${browser}       chrome

*** Keywords ***

Begin Web Test
   Open Browser     about:blank     ${browser}
   Load Page
   #Verify Home

Load Page
   Go To                            ${url}
   Maximize Browser Window

Verify Home
   Page Should Contain              Welcome
   Page Should Contain Element      link:Login
   Page Should Contain Element      link:Register
   Page Should Contain Element      link:About
   Page Should Contain Element      link:Privacy

Click Register Link
   Click Link                       xpath://*[@id="navbar_item_3"]

Input Email
   [Arguments]      ${username}
   Input Text       id:Email    ${username}
Input Password
   [Arguments]      ${password}
   Input Text       id:Password    ${password}
Input CnfmPwd
   [Arguments]      ${cnfm_pwd}
   Input Text       id:ConfirmPassword    ${cnfm_pwd}

Click Register Button
   Click Button                     xpath:/html/body/div/main/div/form/div[8]/input

Click Login Button
   Click Button                     xpath://*[@id="loginForm"]/div[4]/button

Login
   Click Element                    xpath://*[@id="navbar_item_4"]

Login Page
   Click Element                    xpath://*[@id="navbar_item_4"]
   Input Text                       id:Email       abc@yahoo.com
   Input Text                       id:Password     Login@123
   Click Button                     xpath://*[@id="loginForm"]/div[4]/button

Logout Button
    Click Element                   xpath://*[@id="navbar_item_5"]
    Page Should Contain Link        xpath://*[@id="navbar_item_4"]

Login Error Message
   Page Should Contain Button       xpath://*[@id="loginForm"]/div[4]/button

Jobs
   Page Should Contain              No Model?
   Click Element                    xpath:/html/body/header/nav/div/div/ul/li[3]/a
   Page Should Contain              Jobs List
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Title
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Description
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Location
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Payment
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Issuer Rep
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Issuer First Name
   Table Header Should Contain      xpath://*[@id="jobs_table"]     Issuer Last Name


Filter By Title
   Input Text                       xpath://*[@id="jobs_table_filter"]/label/input      Driver
   ${rows}                          Get Element Count   xpath://*[@id="jobs_table"]/tbody/tr
   Log To Console                   ${rows}
   Should Be Equal As Strings       ${rows}     10
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     2   1   Driver
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     2   2   My Drivers will not install
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     2   3   Göteborg
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     2   4   1031
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     2   5   12
   Table Row Should Contain         xpath://*[@id="jobs_table"]     10  Driver

   Click Element                   xpath://*[@id="jobs_table_paginate"]/span/a[2]
   Page Should Contain             Showing 11 to 20 of 33 entries (filtered from 149 total entries)
   Click Element                   xpath://div[@id='jobs_table_paginate']/span/a[3]
   Page Should Contain             Showing 21 to 30 of 33 entries (filtered from 149 total entries)
   Click Element                   xpath://div[@id='jobs_table_paginate']/span/a[4]
   Page Should Contain             Showing 31 to 33 of 33 entries (filtered from 149 total entries)
   Click Element                   xpath://*[@id="jobs_table_paginate"]/span/a[3]
   Page Should Contain             Showing 21 to 30 of 33 entries (filtered from 149 total entries)
   Click Element                   xpath://*[@id="jobs_table_paginate"]/span/a[2]
   Page Should Contain             Showing 11 to 20 of 33 entries (filtered from 149 total entries)
   Click Element                   xpath://*[@id="jobs_table_paginate"]/span/a[1]
   Page Should Contain             Showing 1 to 10 of 33 entries (filtered from 149 total entries)

Filter By Location
   Input Text                       xpath://*[@id="jobs_table_filter"]/label/input      Göteborg
   ${rows}                          Get Element Count   xpath://*[@id="jobs_table"]/tbody/tr
   Log To Console                   ${rows}
   Should Be Equal As Strings       ${rows}     10
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     4   1   Blue screen
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     4   2   I get blue screens frequently
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     4   3   Göteborg
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     4   4   	525
   Table Cell Should Contain        xpath://*[@id="jobs_table"]     4   5   8
   Table Row Should Contain         xpath://*[@id="jobs_table"]     10  Göteborg

   Click Element                    xpath://*[@id="jobs_table_paginate"]/span/a[2]
   Page Should Contain              Showing 11 to 20 of 31 entries (filtered from 149 total entries)
   Click Element                    xpath://div[@id='jobs_table_paginate']/span/a[3]
   Page Should Contain              Showing 21 to 30 of 31 entries (filtered from 149 total entries)
   Click Element                    xpath://div[@id='jobs_table_paginate']/span/a[4]
   Page Should Contain              Showing 31 to 31 of 31 entries (filtered from 149 total entries)

   Click Element                    xpath://*[@id="jobs_table_paginate"]/span/a[3]
   Page Should Contain              Showing 21 to 30 of 31 entries (filtered from 149 total entries)
   Click Element                    xpath://*[@id="jobs_table_paginate"]/span/a[2]
   Page Should Contain              Showing 11 to 20 of 31 entries (filtered from 149 total entries)
   Click Element                    xpath://*[@id="jobs_table_paginate"]/span/a[1]
   Page Should Contain              Showing 1 to 10 of 31 entries (filtered from 149 total entries)

Users

    Click Element                   xpath:/html/body/header/nav/div/div/ul/li[4]/a
    Page Should Contain             Users List
    Table Header Should Contain     xpath://*[@id="users_table"]    First Name
    Table Header Should Contain     xpath://*[@id="users_table"]    Last Name
    Table Header Should Contain     xpath://*[@id="users_table"]    Reputation
    Table Header Should Contain     xpath://*[@id="users_table"]    Tel
    Table Header Should Contain     xpath://*[@id="users_table"]    Location

Filter By First Name
   Input Text                       xpath://*[@id="users_table_filter"]/label/input      Pamela
   ${rows}                          Get Element Count   xpath://*[@id="users_table"]/tbody/tr
   Log To Console                   ${rows}

   Table Cell Should Contain        xpath://*[@id="users_table"]      2   1   Pamela
   Table Cell Should Contain        xpath://*[@id="users_table"]      2   2   Reed
   Table Cell Should Contain        xpath://*[@id="users_table"]      2   3   11
   Table Cell Should Contain        xpath://*[@id="users_table"]      2   4   123
   Table Cell Should Contain        xpath://*[@id="users_table"]      2   5   Stockholm
   Table Row Should Contain         xpath://*[@id="users_table"]      1   Pamela
   Click Element                    xpath://*[@id="users_table_next"]
   Page Should Contain              Showing 1 to 1 of 1 entries (filtered from 19 total entries)
   Click Element                    xpath://*[@id="users_table_previous"]
   Page Should Contain              Showing 1 to 1 of 1 entries (filtered from 19 total entries)

Filter By Last Name
   Input Text                       xpath://*[@id="users_table_filter"]/label/input      Walker
   ${rows}                          Get Element Count   xpath://*[@id="users_table"]/tbody/tr
   Log To Console                   ${rows}

   Table Cell Should Contain        xpath://*[@id="users_table"]      4   1   Victor
   Table Cell Should Contain        xpath://*[@id="users_table"]      4   2   Walker
   Table Cell Should Contain        xpath://*[@id="users_table"]      4   3   5
   Table Cell Should Contain        xpath://*[@id="users_table"]      4   4   123
   Table Cell Should Contain        xpath://*[@id="users_table"]      4   5   Stockholm
   Table Row Should Contain         xpath://*[@id="users_table"]     3   Walker
   Click Element                    xpath://*[@id="users_table_next"]
   Page Should Contain              Showing 1 to 3 of 3 entries (filtered from 19 total entries)
   Click Element                    xpath://*[@id="users_table_previous"]
   Page Should Contain              Showing 1 to 3 of 3 entries (filtered from 19 total entries)

Sorting
    Click Element                   xpath://*[@id="users_table"]/thead/tr/th[2]
    Click Element                   xpath://*[@id="users_table"]/thead/tr/th[1]

Print
   Click Element                    xpath:/html/body/div/main/div/div/form/div/div[1]/button
   Page Should Contain              Index - Webteam2

End Web Test
   Close Browser
