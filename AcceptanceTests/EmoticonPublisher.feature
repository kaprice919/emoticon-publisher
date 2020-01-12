Feature: Reply to emoticon requests with the correct emoticon

Scenario: Respond to a slack user's request for a koala emoticon
    Given the slack command emoticon is run
    When the EmoticonPublisher function gets a POST request with the following data
    Then we respond to slack with the following data