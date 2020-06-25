using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;

public class LevelController : SingletonBehaviour<LevelController>
{
    [Header("[Shared Variables]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt[] constantStackScores;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantStackScoreC;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantGridWidth;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantGridHeight;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantStackCount;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool levelStateGameStart;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableBool levelStateGameOver;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableVector3 playerInputDirection;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt playerScoreCurrent;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt playerScoreTop;

    [Header("[Shared Events]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnLevelGameStart;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnLevelGameOver;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnPlayerInputDirection;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedEvent eventOnPlayerInputDirectionCancel;

    [Header("[Object Prefabs]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private GameObject prefabCellObject;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private GameObject[] prefabStackObject;

    [Header("[Properties]")]
    [SerializeField] private GameObject[,] levelGridCells;

    private void Start()
    {
        InitializeLevel();
    }

    private void InitializeLevel()
    {
        levelGridCells = new GameObject[levelConstantGridWidth.Value, levelConstantGridHeight.Value];

        for (int y = 0; y < levelConstantGridHeight.Value; y++)
        {
            for (int x = 0; x < levelConstantGridWidth.Value; x++)
            {
                SpawnCellObject(x, y);
            }
        }

        SpawnStackObject(0, 0, 0);
    }

    private void SpawnCellObject(int x, int y)
    {
        var cellObject = Instantiate(prefabCellObject, transform);

        var positionX = x - Mathf.Floor(levelConstantGridWidth.Value * 0.5f);
        var positionZ = y - Mathf.Floor(levelConstantGridHeight.Value * 0.5f);

        var position = new Vector3(positionX, 0f, positionZ);

        cellObject.transform.position = position;
        cellObject.transform.SetParent(transform);

        levelGridCells[x, y] = cellObject;
    }

    private void SpawnStackObject(int x, int y, int index, int count = 1)
    {
        var stackObject = Instantiate(prefabStackObject[index], transform).GetComponent<StackObject>();

        var currentCell = levelGridCells[x, y].GetComponent<CellObject>();

        stackObject.SetCell(currentCell);
        stackObject.SetStackCount(count);
        currentCell.SetStack(stackObject);
    }

    private void SpawnRandomStackObject(int x, int y, int count = 1)
    {
        var index = Random.Range(0, levelConstantStackCount.Value);

        SpawnStackObject(x, y, index, count);
    }

    private bool ValidateCurrentLevelState()
    {
        var direction = new Vector2[] { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

        for (int y = 0; y < levelConstantGridHeight.Value; y++)
        {
            for (int x = 0; x < levelConstantGridWidth.Value; x++)
            {
                var currentCell = levelGridCells[x, y].GetComponent<CellObject>();

                if (!currentCell.HasStack)
                    return false;

                var currentStack = currentCell.GetStack;

                for (int i = 0; i < direction.Length; i++)
                {
                    var nextIndexX = x + (int)direction[i].x;
                    var nextIndexY = y + (int)direction[i].y;

                    if (nextIndexX < 0 || nextIndexX >= levelConstantGridWidth.Value)
                        continue;

                    if (nextIndexY < 0 || nextIndexY >= levelConstantGridHeight.Value)
                        continue;

                    var nextCell = levelGridCells[nextIndexX, nextIndexY].GetComponent<CellObject>();

                    if (!nextCell.HasStack)
                        return false;

                    var nextStack = nextCell.GetStack;

                    if (currentStack.GetStackId.Equals(nextStack.GetStackId))
                        if (currentStack.GetStackCount.Equals(nextStack.GetStackCount))
                            return false;
                }
            }
        }

        return true;
    }

    public void OnInputPlayerDirection()
    {
        if (ValidateCurrentLevelState())
        {
            //To Do :: File Output :: Current Score
            //To Do :: File Output :: Top Score

            eventOnLevelGameOver.Raise();
        }

        else
        {
            if (IterateCellsAtDirection())
            {
                //To Do :: Polish :: Animation :: Move
                //To Do :: Polish :: Animation :: Join
                //To Do :: Polish :: Animation :: Collect

                SpawnStackAtDirection();
            }

            else
            {
                //To Do :: Polish :: Sound Effect :: Warning

                eventOnPlayerInputDirectionCancel.Raise();
            }
        }
    }


    private void SpawnStackAtDirection()
    {
        var randX = 0; var randY = 0;

        while (true)
        {
            if (playerInputDirection.Value.Equals(Vector3.zero))
                return;

            else if (playerInputDirection.Value.Equals(Vector3.forward))
            {
                Debug.Log("Spawn At Player Input Direction :: Foward");

                randX = Random.Range(0, levelConstantGridWidth.Value);
                randY = 0;
            }

            else if (playerInputDirection.Value.Equals(Vector3.back))
            {
                Debug.Log("Spawn At Player Input Direction :: Back");

                randX = Random.Range(0, levelConstantGridWidth.Value);
                randY = levelConstantGridHeight.Value - 1;
            }

            else if (playerInputDirection.Value.Equals(Vector3.right))
            {
                Debug.Log("Spawn At Player Input Direction :: Right");

                randX = 0;
                randY = Random.Range(0, levelConstantGridHeight.Value);
            }

            else if (playerInputDirection.Value.Equals(Vector3.left))
            {
                Debug.Log("Spawn At Player Input Direction :: Left");

                randX = levelConstantGridWidth.Value - 1;
                randY = Random.Range(0, levelConstantGridHeight.Value);
            }

            if (!levelGridCells[randX, randY].GetComponent<CellObject>().HasStack)
                break;
        }

        SpawnRandomStackObject(randX, randY);
    }

    private bool IterateCellsAtDirection()
    {
        var validation = false;

        if (playerInputDirection.Value.Equals(Vector3.zero))
            return false;

        else if (playerInputDirection.Value.Equals(Vector3.forward))
        {
            Debug.Log("Player Input Direction :: Forward");

            for (int x = 0; x < levelConstantGridHeight.Value; x++)
            {
                for (int y = levelConstantGridHeight.Value - 1; y >= 0; y--)
                {
                    if (y == levelConstantGridHeight.Value - 1)
                        continue;

                    var current = levelGridCells[x, y].GetComponent<CellObject>();
                    var next = levelGridCells[x, y + 1].GetComponent<CellObject>();

                    if (MoveOrJoinStack(current, next))
                        if (!validation) validation = true;
                }
            }
        }

        else if (playerInputDirection.Value.Equals(Vector3.back))
        {
            Debug.Log("Player Input Direction :: Back");

            for (int x = 0; x < levelConstantGridWidth.Value; x++)
            {
                for (int y = 0; y < levelConstantGridHeight.Value; y++)
                {
                    if (y == 0)
                        continue;

                    var current = levelGridCells[x, y].GetComponent<CellObject>();
                    var next = levelGridCells[x, y - 1].GetComponent<CellObject>();

                    if (MoveOrJoinStack(current, next))
                        if (!validation) validation = true;
                }
            }
        }

        else if (playerInputDirection.Value.Equals(Vector3.right))
        {
            Debug.Log("Player Input Direction :: Right");

            for (int y = 0; y < levelConstantGridHeight.Value; y++)
            {
                for (int x = levelConstantGridWidth.Value - 1; x >= 0; x--)
                {
                    if (x == levelConstantGridWidth.Value - 1)
                        continue;

                    var current = levelGridCells[x, y].GetComponent<CellObject>();
                    var next = levelGridCells[x + 1, y].GetComponent<CellObject>();

                    if (MoveOrJoinStack(current, next))
                        if (!validation) validation = true;
                }
            }
        }

        else if (playerInputDirection.Value.Equals(Vector3.left))
        {
            Debug.Log("Player Input Direction :: Left");

            for (int y = 0; y < levelConstantGridHeight.Value; y++)
            {
                for (int x = 0; x < levelConstantGridWidth.Value; x++)
                {
                    if (x == 0)
                        continue;

                    var current = levelGridCells[x, y].GetComponent<CellObject>();
                    var next = levelGridCells[x - 1, y].GetComponent<CellObject>();

                    if (MoveOrJoinStack(current, next))
                        if (!validation) validation = true;
                }
            }
        }

        return validation;
    }

    private bool MoveOrJoinStack(CellObject currentCell, CellObject targetCell)
    {
        //Cell is Empty
        if (!currentCell.HasStack)
            return true;

        //Cell is not Empty
        else if (currentCell.HasStack)
        {
            //Cell is not Empty but Next Cell is Empty
            if (!targetCell.HasStack)
            {
                return MoveStack(currentCell, targetCell);
            }

            //Cell is not Empty as well as Next Cell is not Empty
            else if (targetCell.HasStack)
            {
                return JoinStack(currentCell, targetCell);
            }
        }

        return false;
    }

    private bool MoveStack(CellObject currentCell, CellObject targetCell)
    {
        var currentStack = currentCell.GetStack;

        currentStack.transform.position = targetCell.transform.position;

        Debug.Log(targetCell.transform.position);

        targetCell.SetStack(currentStack);
        currentCell.UnsetStack();

        return true;
    }

    private bool JoinStack(CellObject currentCell, CellObject targetCell)
    {
        var currentStack = currentCell.GetStack;
        var targetStack = targetCell.GetStack;

        if (currentStack.GetStackId.Equals(targetStack.GetStackId))
        {
            if (currentStack.GetStackCount.Equals(targetStack.GetStackCount))
            {
                if (currentStack.GetStackCount < 5)
                {
                    //To Do :: Refactor :: Object Pool

                    currentCell.UnsetStack();
                    targetStack.IncreaseStackCount();
                    Destroy(currentStack.gameObject);
                }

                else if (currentStack.GetStackCount >= 5)
                {
                    //To Do :: Refactor :; Object Pool

                    currentCell.UnsetStack();
                    targetCell.UnsetStack();
                    CollectStacks(currentStack, targetStack);
                }

                return true;
            }
        }

        return false;
    }

    private void CollectStacks(StackObject currentStack, StackObject targetStack)
    {
        //To Do :: Refactor :: Object Pool
        //To Do :: Polish :: Sound Effect

        Destroy(currentStack.gameObject);
        Destroy(targetStack.gameObject);

        playerScoreCurrent.Value += constantStackScoreC.Value;

        if (playerScoreTop.Value < playerScoreCurrent.Value)
            playerScoreTop.Value = playerScoreCurrent.Value;
    }

    private IEnumerator CollectAllStacksCoroutine()
    {
        for (int y = 0; y < levelConstantGridHeight.Value; y++)
        {
            for (int x = 0; x < levelConstantGridWidth.Value; x++)
            {
                //To Do :: Polish :: Animation
                //To Do :: Polish :: Sound Effect

                var currentCell = levelGridCells[x, y].GetComponent<CellObject>();
                var currentStack = currentCell.GetStack;

                currentCell.UnsetStack();

                var score = constantStackScores[currentStack.GetStackCount - 1].Value;

                playerScoreCurrent.Value += score;
                Destroy(currentStack.gameObject);

                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    public void CollectAllStacks()
    {
        StartCoroutine(CollectAllStacksCoroutine());
    }
}
