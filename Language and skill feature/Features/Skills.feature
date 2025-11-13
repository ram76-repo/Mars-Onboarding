@Skills
Feature: Skills feature

As a registered user I want to login to the portal with valid credentials 
and add, edit and delete records in the language and skill module
so that i can show my language and skill proficiency to the recruiters

Background: 
	Given I logged into the portal successfully
	And I navigate to the skills tab


Scenario Outline: Create new skill record with valid data
	When I add a new skill with valid '<Skill>' and '<Level>' data
	Then the new '<Skill>' and '<Level>' should be created successfully
Examples:
	| Skill         | Level        |
	| Java          | Expert       |
	| Python        | Intermediate |
	| SQL           | Expert       |
	| Communication | Beginner     |

Scenario Outline: Create new skill record with invalid data
	When I add a new skill with invalid '<Skill>' and valid '<Level>' data
	Then I should see an error message for invalid Skill

	Examples:
	| Skill | Level |
	| 12345 | Expert |

	Scenario Outline: Create new skill record with blank for skill
	When I add a new skill with blank '<Skill>' and valid '<Level>' data
	Then I should see an error message for blank Skill

	Examples:
	| Skill   | Level         |
	|         | Intermediate  |	

Scenario Outline: Create new skill record with blank for level
	When I add a new skill with valid '<Skill>' and blank '<Level>' data
	Then I should see an error message for blank Level
Examples:
	| Skill | Level |
	| Java  |       |

Scenario Outline: Create new skill record with blank data
	When I add a blank '<Skill>' and blank '<Level>' data
	Then I should see an error message
Examples:
	| Skill | Level |
	|       |       |

Scenario: Check if user is unable to create a duplicate skill record
	And I add a new skill

	| Skill         | Level  |
	| Java          | Expert |

	When I try to add the same skill again 

	| Skill         | Level  |
	| Java          | Expert |
	Then I should see an error message for duplicate


Scenario: Check if user is able to edit a skill record
	And I add a new skill 

	| Skill             | Level  |
	| Microsoft Office  | Expert |

	When I edit this record 
	| Skill  | Level |
	| Python    | Beginner   |

	Then the skill record should be updated successfully

Scenario Outline: Check if user is unable to edit and save a skill record with blank level field
	And I add a new skill
		| Skill | Level  |
		| Java  | Expert |

	When I edit this record with '<Skill>' data and blank '<Level>'		     		
	Then I should see an error message for blank Level
	Examples:
	| Skill | Level |
	| Adobe Photoshop  |       |

Scenario Outline: Check if user is unable to edit and save a skill record with blank skill field
And I add a new skill

        | Skill     | Level  |
        | Designing | Expert |

	When I edit this record with blank '<Skill>' and valid '<Level>'
Then I should see an error message for blank Skill

Examples:
	| Skill | Level |
	|       | Beginner |

Scenario: Check if user is able to cancel the changes
	And I add a new skill
        | Skill      | Level  |
		| Designing  | Expert |

	When I edit this record and click on cancel
	| Skill | Level |
		| Selenium | Beginner |
			
	Then the changes should not be saved

	
Scenario: Check if user is able to delete a skill record
	And I add a new skill
		| Skill    | Level  |
		| Tableau  | Beginner |
	When I delete this record
	Then the skill record should be deleted successfully







	


