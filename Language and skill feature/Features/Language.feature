@Language

Feature: language feature

As a registered user I want to login to the portal with valid credentials 
and add, edit and delete records in the language and skill module
so that i can show my language and skill proficiency

Background: 
	Given I logged into the portal succesfully
	And I navigate to the profile page


@addlanguagerecordwithvaliddata				
Scenario Outline: Create new language record with valid data
	When I create a new language record with valid '<languageName>' and '<proficiencyLevel>' data
	Then the new language record with valid '<languageName>' and '<proficiencyLevel>' should be created successfully
	Examples:
	| languageName   | proficiencyLevel |
	| English        | Fluent           |
	| French         | Basic            |
	| German         | Basic            |
	| Spanish        | Conversational   |
	


Scenario Outline: Create new language record with blank for language name
	When I create a new language record with blank '<languageName>' and valid '<proficiencyLevel>' data
	Then I should see an error message for blank language name
	Examples:
	| languageName   | proficiencyLevel |
	|                | Fluent           |	


Scenario Outline: Create new language record with blank for proficiency level
	When I create a new language record with valid '<languageName>' and blank '<proficiencyLevel>' data
	Then I should see an error message for blank proficiency level
	Examples:
	| languageName   | proficiencyLevel |
	| Italian        |            |		

@newlanguagerecordwithinvaliddata
 Scenario Outline: Create new language record with invalid data
	When I create a new language record with invalid '<languageName>' and valid '<proficiencyLevel>' data
	Then the new language record with invalid '<languageName>' should not be created
	Examples:
	| languageName   | proficiencyLevel |
	| ABC@123        | Fluent           |

@newlanguagerecordwithduplicatedata
Scenario: Check if user is unable to create a duplicate language record
	When I create a new record with valid data
	
	| languageName   | proficiencyLevel |
	| English        | Fluent           |
	
	And I try to create another record with the same data

	| languageName   | proficiencyLevel |
	| English        | Fluent           |

	Then I should see an error message for duplicate record
	
		

Scenario:  Check if user is unable to create more than 4 language records
	When I try to create more than four records
	| languageName | proficiencyLevel |
	| English      | Fluent           |
	| French       | Basic            |
	| German       | Basic            |
	| Spanish      | Conversational   |
	| Russian      | Fluent           |
		
	Then I should not be allowed to create more than four records	
			
@editlanguagerecordwithvaliddata
Scenario: Check if user is able to edit and save existing language record

When I add new record to the language module
		| languageName | proficiencyLevel |
		| English      | Fluent           |
		

	And I edit the record with new data
		| languageName | proficiencyLevel |
		| Italian      | Conversational   |


	Then the language record should be updated with new data
	| languageName | proficiencyLevel |
		| Italian      | Conversational   |
		
	

@editlanguagerecordwithblanklanguage
Scenario Outline: Check if user is not allowed to edit and save existing record with blank language name
When I create a new language record
	| languageName | proficiencyLevel |
		| Spanish      | Conversational   |

And I edit the record with blank '<languageName>' and valid '<proficiencyLevel>'	
Then I should see an error message for blank language field

Examples:
	| languageName | proficiencyLevel |
	|              | Conversational   |
	
		

@editlanguagerecordwithblankproficiency
Scenario Outline: Check if user is not allowed to edit and save existing record with blank proficiency level

When I create a new language record
	| languageName | proficiencyLevel |
		| Spanish      | Conversational   |

	And I edit the record with valid '<languageName>' and blank '<proficiencyLevel>' data
	Then I should see an error message for blank proficiency level field
		
Examples:
	| languageName | proficiencyLevel |
	| German       |                  |

@editlanguagerecordwithinvaliddata
Scenario Outline: Check if user is not allowed to edit and save invalid record

When I create a new language record
	| languageName | proficiencyLevel |
	| Russian      | Conversational   |

	And I edit the record with invalid '<languageName>' and '<proficiencyLevel>' data
	Then I should see an error message for invalid data
		
Examples:
	| languageName | proficiencyLevel |
	| XYZ@456      | Basic            |

@cancelchanges
Scenario Outline: Check if user is allowed to cancel the changes made to a record

When I create a new language record
	| languageName | proficiencyLevel |
	| Russian      | Conversational   |

	And I edit the record with new '<languageName>' and '<proficiencyLevel>' data and click cancel
	Then the language record should not be updated with new data	
		
Examples:
	| languageName | proficiencyLevel |
	| Telugu      | Conversational   |
	
@deletelanguagerecord
Scenario: Check if user is able to delete an existing language record

When I create a new language record
	| languageName | proficiencyLevel |
	| Russian      | Conversational   |

	And I delete the record 
	Then the language record should be deleted successfully

@addprofiledescription
Scenario Outline: Check if user is  allowed to add and save the profile description
	When I add a profile description with valid '<profileDescription>'
	Then the profile description should be saved successfully

	Examples:
	| profileDescription |
	| I am a software engineer with 5 years of experience in web development. |

@blankprofiledescription
Scenario: Check if user is not allowed to leave the profile description blank
	When I delete the existing text and leave a blank for the profile description and save
	Then it should show an error message

@profiledescriptionlessthan600characters
Scenario Outline: Check if user is not allowed to add more than 600 characters in profile description
	When I add a '<profileDescription>' with more than "600" characters
	Then it should not accept additional characters
Examples:
	| profileDescription                                                                                                                                                                                                                                                                                                                                                                                                                                            |
	| I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience.I am a software developer with 10 years of professional experience. |

	


