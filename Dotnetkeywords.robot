*** Settings ***
Library     SeleniumLibrary
Library     DateTime

*** Keywords ***

Begin Web Test
    Open Browser      about:blank     ${browser}

Load Page
   Go To                          ${url}
   Maximize Browser Window
