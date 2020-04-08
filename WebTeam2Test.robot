*** Settings ***

Library          SeleniumLibrary
Library          DateTime
Resource         Dotnetkeywords.robot

*** Variables ***

${url}           https://localhost:44373/
${browser}       chrome

*** Test Cases ***

Login page
     Begin Web Test
     Load Page

