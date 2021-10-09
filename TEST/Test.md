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

## Failed Samples
### First command is not PLACE
a)
```
RIGHT
```
b)
```
MOVE
```
c)
```
REPORT
```
### Invalid command
a)
```
PLACE 3,2,LEFT
```
b)
```
PLACE 1,4,WEST
MOVEE
```
c)
```
PLACE 1,4,WEST
ROBCT 2
```
d)
```
PLACE WEST,4,1
```
### Robot is not on table
a)
```
PLACE 5,2,WEST
```
b)
```
PLACE -1,2,EAST
```
### Robot is going to fall
a)
```
PLACE 1,2,EAST
PLACE 4,4,WEST
MOVE
```
b)
```
PLACE 1,1,WEST
MOVE
MOVE
```
c)
```
PLACE 2,3,NORTH
PLACE 1,2,EAST
ROBOT 1
MOVE
MOVE
```
