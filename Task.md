

#SIS Task:
RESTful Service
Create a RESTful web service that can be accessed via HTTP. The service should allow users to capture and query retrospective (SCRUM ceremony) outcomes. A retrospective is a SCRUM ceremony that allows development teams to reflect on their software delivery during previous iteration (sprint).
A retrospective has the following properties:
- Name (unique identifier)
- Summary
- Date
- Participants (collection of names)
- Feedback items, whereby each item contains the following properties:
o Name of the person providing feedback
o Body
o Type of feedback (positive, negative, idea, praise)
Create New Retrospective
Create an end-point that will allow you to create a new retrospective by submitting a JSON object containing retrospective properties. When creating a retrospective, the feedback items should be empty.
It should not be possible to create a retrospective without date or participants.
Add Feedback Items to Retrospective
Create an end-point that will allow you to add feedback items to the newly created (existing) retrospective. You should be able to add one feedback item at a time.
Search Retrospectives
- Create an end-point for returning all the retrospectives.
- Create an end-point for searching retrospectives by date.
This should return either JSON or XML depending on the content type specified in the request header.
2
Interface
Create a simple web interface using AngularJS or React that allows you to do the following:
- View all retrospectives
- Search retrospective by dates
- Add new retrospectives
- Add feedback items into the existing retrospective
Please do not spend any time on styling as we are mainly interested in functionality and how you structure client and server side code.
Other Requirements
Logging
Application should have basic logging for debugging and error handling purposes.
Unit Testing
Application should have few unit tests.
Notes
Retrospective data does not need to be persisted. It’s acceptable to store data in memory and lose it on application restart.
