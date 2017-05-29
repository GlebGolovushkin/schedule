Feature: WebTests

Scenario: Test Student table
	When the user sets 'студента' schedule
		And the user sets '2' x
		And the user sets 'ИВТФ' faculty
		And the user sets '1' course '41' group
	Then '1–41' schedule is opened 

Scenario: Test Teacher table
	When the user sets 'преподавателя' schedule
		And the user sets 'Филатов А.А.' teacher
	Then 'Филатов А.А.' schedule is opened 

Scenario: Test Auditor table
	When the user sets 'аудитории' schedule
		And the user sets 'Б' building
		And the user sets '306' auditor
	Then 'Б-306' schedule is opened 
