Feature: UITests

#Scenario: Test Student table
#	When the user sets 'студента' schedule
#		And the user sets '2' x
#		And the user sets 'ИВТФ' faculty
#		And the user sets '1' course '41' group
#	Then '1–41' schedule is opened 
#
#Scenario: Test Teacher table
#	When the user sets 'преподавателя' schedule
#		And the user sets 'Филатов А.А.' teacher
#	Then 'Филатов А.А.' schedule is opened 
#
#Scenario: Test Auditor table
#	When the user sets 'аудитории' schedule
#		And the user sets 'Б' building
#		And the user sets '306' auditor
#	Then 'Б-306' schedule is opened 
#
#Scenario: Test tool tip menu Admin and fail pass
#	When the user sets 'Администратор' in tool tip menu
#		And the user sets '123' as admin password
#	Then pop up with 'Неверный пароль' text appears
#	When the user sets Ok in pop up
#	Then the user does not have admin abilities

Scenario: Test tool tip menu Admin and true pass
	When the user sets 'Администратор' in tool tip menu
		And the user sets 'password123' as admin password
	Then pop up with 'Пароль введён верно' text appears
	When the user sets Ok in pop up
	Then the user has admin abilities
