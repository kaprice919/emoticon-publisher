Feature: Reply to emoticon requests with the correct emoticon

Scenario: Respond to a slack user's request for a koala emoticon
    Given the slack command emoticon is run
    When the EmoticonPublisher function gets a POST request with the following data
    """
    token=B7IhuJTdv5vm1Vw5pFgYU6Vk&team_id=T8MC9SLTF&team_domain=hidigitalsolutionsllc&channel_id=DLN74UE2H&channel_name=directmessage&user_id=ULN6JH916&user_name=kevin.price&command=%2Femoticon&text=koala&response_url=https%3A%2F%2Fhooks.slack.com%2Fcommands%2FT8MC9SLTF%2F904991654262%2FrGHdp1CnkpdWQbYdlvzgmgdk&trigger_id=904643602359.293417904933.728511c146e9c4e86aae64d06bd7e82e
    """
    Then we respond to slack with the following data
    """
    {"response_type" = "in_channel", "text" = "responseString"}
    """
