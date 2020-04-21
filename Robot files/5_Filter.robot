*** Settings ***

Library           SeleniumLibrary
Library           DateTime
Resource          ../Resources/Webteam2keywords.robot
Suite Setup       Begin Web Test
Suite Teardown    End Web Test

*** Variables ***

${url}            https://localhost:44373/
${browser}        chrome

*** Test Cases ***

Jobs list
    [Documentation]             Test for jobs list page
    [Tags]                      Filter_TC 1
    Jobs

Jobs Filter
    [Documentation]             Test for filter in jobs list
    [Tags]                      Filter_TC 2
    Filter By Title
    Filter By Location

Users page
    [Documentation]             Test for users page
    [Tags]                      Filter_TC 3
    Users

Users Filter
    [Documentation]             Test for filter in users page
    [Tags]                      Filter_TC 4
    Filter By First Name
    Filter By Last Name

Sorting
    [Documentation]             Test for sorting
    [Tags]                      Filter_TC 5
    Sorting





