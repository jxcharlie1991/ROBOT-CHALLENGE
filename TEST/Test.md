# ROBOT CHALLENGE TEST SAMPLES
Note: This program is not case sensitive, place == PLACE == PlAcE

This test samples includes two samples.

[Succeed Samples](#succeed-samples)

[Failed Samples](#failed-samples)

- [First command is not PLACE](#first-command-is-not-place)
- [Invalid command](#invalid-command)
- [Robot is not on table](#robot-is-not-on-table)
- [Robot is going to fall](#robot-is-going-to-fall)

## Succeed Samples
a.
```
PLACE 2,3,EAST
PLACE 1,1,WEST
PLACE 0,4,NORTH
PLACE 3,3,SOUTH
ROBOT 3
RIGHT
MOVE
MOVE
REPORT
```
Expected Outcome
```
ROBOT 1: 2, 3, EAST
ROBOT 2: 1, 1, WEST
ROBOT 3: 2, 4, EAST    ACTIVE
ROBOT 4: 3, 3, SOUTH
```
b.
```
PLACE 1,4,WEST
PLACE 2,2,NORTH
PLACE 1,2,EAST
PLACE 3,1,SOUTH
PLACE 2,0,EAST
ROBOT 1
MOVE
LEFT
ROBOT 2
RIGHT
MOVE
ROBOT 5
LEFT
MOVE
MOVE
REPORT
```
Expected Outcome
```
ROBOT 1: 0, 4, SOUTH
ROBOT 2: 3, 2, EAST
ROBOT 3: 1, 2, EAST
ROBOT 4: 3, 1, SOUTH
ROBOT 5: 2, 2, NORTH    ACTIVE
```
C.
```
PLACE 2,0,EAST
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
MOVE
REPORT
```
Expected Outcome
```
ROBOT 1: 2, 0, EAST
ROBOT 2: 3, 4, NORTH    ACTIVE
```
## Failed Samples
### First command is not PLACE
a)
```
RIGHT
```
Expected Outcome
```
ERROR!!! The first command has to be PLACE command, please try again.
```
b)
```
MOVE
```
Expected Outcome
```
ERROR!!! The first command has to be PLACE command, please try again.
```
c)
```
REPORT
```
Expected Outcome
```
ERROR!!! The first command has to be PLACE command, please try again.
```
### Invalid command
a)
```
PLACE 3,2,LEFT
```
Expected Outcome
```
ERROR!!! Please input a valid PLACE command as the first command.
```
b)
```
PLACE 1,4,WEST
MOVEE
```
Expected Outcome
```
ERROR!!! Invalid command input, please try again.
```
c)
```
PLACE 1,4,WEST
ROBCT 2
```
Expected Outcome
```
ERROR!!! Invalid command input, please try again.
```
d)
```
PLACE 1,4,WEST
PLACE WEST,4,1
```
Expected Outcome
```
ERROR!!! Please input a valid PLACE command.
```
### Robot is not on table
a)
```
PLACE 5,2,WEST
```
Expected Outcome
```
ERROR!!! This robot is not on the table, this command would not execute, you MUST place the robot on the table.
```
b)
```
PLACE -1,2,EAST
```
Expected Outcome
```
ERROR!!! This robot is not on the table, this command would not execute, you MUST place the robot on the table.
```
### Robot is going to fall
a)
```
PLACE 1,2,EAST
PLACE 0,4,WEST
MOVE
```
Expected Outcome
```
ERROR!!! ROBOT 2 is going to fall from the table, this command would not execute, please try again.
```
b)
```
PLACE 1,1,WEST
MOVE
MOVE
```
Expected Outcome
```
ERROR!!! ROBOT 1 is going to fall from the table, this command would not execute, please try again.
```
c)
```
PLACE 2,3,NORTH
PLACE 1,2,EAST
ROBOT 1
MOVE
MOVE
```
Expected Outcome
```
ERROR!!! ROBOT 1 is going to fall from the table, this command would not execute, please try again.
```
### Change to an incorrect serial number robot
a)
```
PLACE 1,2,EAST
PLACE 4,4,WEST
ROBOT 3
```
Expected Outcome
```
ERROR!!! Please select a valid robot. There are only 2 robots on the desk
```
b)
```
PLACE 3,2,EAST
PLACE 2,4,WEST
ROBOT 0
```
Expected Outcome
```
ERROR!!! Please select a valid robot. There are only 2 robots on the desk
```
