# AUBG SuggectionBox

## Description
An interactive application for proposing suggestions and improvements by the faculty, students and staff of AUBG.

## Functional Requirement
SuggestionBox offers the following main functionalities to the user:
 * The ability to propose suggestions with a title, description and associated university office
 * A simple voting system that tracks the popularity of suggestions
 * A commenting system facilitating the discussion of suggestions through the web application
 * The ability to sort suggestions by a several criteria

## Suggestion Type
There are two dimension by which suggestions can vary:
 * Suggestion privacy - Suggestions can be private or public. Public suggestions will be visible to all visitors of the application.
 Public suggestions can also accumulate votes. Private suggestions will only be visible to the associated university office.
 * Suggestion anonymity - Users who do not log in can choose to post an anonymous suggestion. Logged in users can create
 named suggestions

## Account Creation
User can register to post named suggestions, comment and vote. A user account
is associated with their AUBG email. On sign up, a confirmation email is sent to the given AUBG
email to confirm the identity of the user.

## Suggestion
A suggestion passes through several states when going through the application:
 1. After submission, a suggestion is sent for review to an admin body. The content of the submission is
 screened for explicit or inappropriate content. The suggestion can be denied and this removed completely
 or it can be approved by the admin and thus sent to the next step.
 2. If the approved suggestion is private it is only visible to the admin.
 Only the admin and the owner of the suggestion (provided the suggestion is not anonymous) can comment on this suggestion.
 If suggestion is public, then it is visible to all users of the web application. Everyone with an account can vote and comment.
 3. The admin can mark the suggestion as resolved after real world actions have been taken or it can be rejected.
