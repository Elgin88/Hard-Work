using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfPointsCreater))]

public class Inventory : MonoBehaviour
{
    private Coroutine _unloadBlocksCoroutine;
    private bool _isFull = false;
    private Vector3 _collectPoint;

    private List<LineOfPoints> _lines = new List<LineOfPoints>();
    private LineOfPointsCreater _lineOfPointsCreater;

    private void Start()
    {
        LineOfPoints[] tempLines = GetComponentsInChildren<LineOfPoints>();

        foreach (LineOfPoints tempLine in tempLines)
        {
            _lines.Add(tempLine);
        }

        _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
    }

    public IEnumerator UnloadBlocks()
    {
        int i = 0;

        while (i < _lines.Count)
        {
            _lines[_lines.Count - i - 1].UploadBlocks(_collectPoint);

            i++;
            yield return new WaitForSeconds(1);
        }
    }

    public void StartCoroutineUnloadBlocks(Vector3 collectPoint)
    {
        _collectPoint = collectPoint;

        if (_unloadBlocksCoroutine==null)
        {
            _unloadBlocksCoroutine = StartCoroutine(UnloadBlocks());
        }
    }

    public void StopCoroutineUnloadBlocks()
    {
        if (_unloadBlocksCoroutine != null)
        {
            StopCoroutine(UnloadBlocks());
        }
    }

    public void CreateLine()
    {
        _lineOfPointsCreater.CreateLine();
    }

    public void AddLine(LineOfPoints line)
    {
        _lines.Add(line);
    }

    public int GetCountOfLines()
    {
        return _lines.Count;
    }

    public Point TryTakePoint()
    {
        if (CheckIsFull() == true)
        {
            CreateLine();
        }

        if (CheckIsFull() == false)
        {
            foreach (LineOfPoints line in _lines)
            {
                Point point = line.TakePoint();

                if (point != null)
                {
                    return point;
                }
            }
        }

        return null;
    }

    public bool CheckIsFull()
    {
        foreach (LineOfPoints line in _lines)
        {
            if (line.CheckIsFull() == false)
            {
                _isFull = false;
                return _isFull;
            }
        }

        _isFull = true;
        return _isFull;
    }
}