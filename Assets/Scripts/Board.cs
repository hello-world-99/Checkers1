using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Board : MonoBehaviour
{
    public GameObject sprpl1;
    public GameObject sprpl2;
    public bool dddd=false;
    public GameObject Win;
    public GameObject Draw;
    public Piece[,] Pieces=new Piece[8,8];
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    private Vector2 Mouse;
    private Vector2 boardOffset= new Vector2(-4f,-4f);
    private Vector2 pieceOffset = new Vector2(0.5f, 0.5f);
    private Vector2 startDrag;
    private bool isPlayer1Turn;
    public bool isPlayer1;
    int scorecount1;
    int scorecount2;
    public bool isWin = false;
    private Vector2 endDrag;
    private Piece selectedPiece;
    private bool isKilled;
    private List<Piece> forcedPieces = new List<Piece>();
    private List<Piece> BlockedPieces = new List<Piece>();
    bool vib=false;
    public int isPlayer1count = 0, isPlayer2count = 0;
    public int Combo = 1;
    public int countblock;
    private void Start()
    {
        forcedPieces = new List<Piece>();
        BlockedPieces = new List<Piece>();
        isPlayer1Turn = true;
        GenerateBoard();
        sprpl1.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f); 
        sprpl2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        scorecount1 = 0;
        scorecount2 = 0;
    }
    private void Update()
    {
        MouseUpdate();
        //Debug.Log(Mouse);
        if ((isPlayer1) ? isPlayer1Turn : !isPlayer1Turn)
        {
            int x = (int)Mouse.x;
            int y = (int)Mouse.y;
            if (selectedPiece != null)
            {
                UpdatePieceDrag(selectedPiece);
            }
            if (Input.GetMouseButtonDown(0))
            {
                SelectPiece(x, y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                TryMove((int)startDrag.x, (int)startDrag.y, x, y);
            }
        }

        if (vib == false)
        {
            CheckVictory();
        }
        if (Input.GetMouseButtonDown(0)&&isWin)
        {
            SceneManager.LoadScene("MainMenu");
        }
        countblock = BlockedPieces.Count;
        //DrawCheck();
        DrawCheck();
        if (((BlockedPieces.Count == isPlayer1count&&isPlayer1Turn) || (BlockedPieces.Count == isPlayer2count && !isPlayer1Turn))&& BlockedPieces.Count!=0)
        {
            if (dddd == false)
            {
                draw();
                dddd = true;
                isWin = true;
            }

        }
    }
    private void TryMove(int x1, int y1, int x2, int y2)
    {
        
        forcedPieces = ScanForPossibleMove();
        startDrag = new Vector2(x1, y1);
        endDrag= new Vector2(x2, y2);
        selectedPiece = Pieces[x1, y1];
        if (x2 < 0 || x2 > 8 || y2 < 0 || y2 > 8)
        {
            if (selectedPiece!=null)
            {
                MovePieces(selectedPiece, x1, y1);
            }
            startDrag = Vector2.zero;
            selectedPiece = null;
            return;
        }
        if (selectedPiece!=null)
        {
            if (endDrag==startDrag)
            {
                MovePieces(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;
                return;
            }
            if(selectedPiece.ValidMove(Pieces,x1,y1,x2,y2))
            {
                if (Mathf.Abs(x2 - x1) == 2)
                {
                    Piece p = Pieces[(x1 + x2) / 2, (y1 + y2) / 2];
                    if(p!=null)
                    {
                        Pieces[(x1 + x2) / 2, (y1 + y2) / 2] = null;
                        Destroy(p.gameObject);
                        isKilled = true;
                        
                        if (!p.isPlayer1)
                        {
                            scorecount1 += 10*Combo;
                           
                            sprpl1.GetComponent<TextMeshProUGUI>().text = "Player 1\nScore: " +scorecount1;
                        }
                        else
                        {
                            scorecount2 += 10*Combo;
                            
                            sprpl2.GetComponent<TextMeshProUGUI>().text = "Player 2\nScore: " + scorecount2;
                        }
                        Combo++;
                    }

                }
                if (forcedPieces.Count!=0&&!isKilled)
                {
                    MovePieces(selectedPiece, x1, y1);
                    startDrag = Vector2.zero;
                    selectedPiece = null;

                    return;
                }
                Pieces[x2, y2] = selectedPiece;
                Pieces[x1, y1] = null;
                MovePieces(selectedPiece, x2, y2);
                
                EndTurn();
            }
            else
            {
                MovePieces(selectedPiece, x1, y1);
                startDrag = Vector2.zero;
                selectedPiece = null;
                return;
            }
        }      
    }

    private void EndTurn()
    {

        int x = (int)endDrag.x;
        int y = (int)endDrag.y;
        if (selectedPiece!=null)
        {
            if (selectedPiece.isPlayer1&&!selectedPiece.isKing&&y==7)
            {
                selectedPiece.isKing = true;
                selectedPiece.transform.Rotate(Vector3.right * 180);
            }
            else if (!selectedPiece.isPlayer1 && !selectedPiece.isKing && y == 0 )
            {
                selectedPiece.isKing = true;
                selectedPiece.transform.Rotate(Vector3.right * 180);
            }
        }
        selectedPiece = null;
        startDrag = Vector2.zero;

        if(ScanForPossibleMove(selectedPiece,x,y).Count!=0&&isKilled)
        {
            return; 
        }
        if (isPlayer1)
        {
            sprpl1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            sprpl2.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f);
        }
        else
        {
            sprpl1.GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f);
            sprpl2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        Combo = 1;
        isPlayer1Turn = !isPlayer1Turn ;
        isPlayer1 = !isPlayer1;
        isKilled = false;
        CheckVictory();
      

    }
    private List<Piece> ScanForPossibleMove(Piece p, int x, int y)
    {
        forcedPieces = new List<Piece>();
        if (Pieces[x,y].isForceToMove(Pieces,x,y))
        {
            forcedPieces.Add(Pieces[x, y]);
        }


        return forcedPieces;
    }
    private void CheckVictory()
    {
        var ps = FindObjectsOfType<Piece>();
        isPlayer1count = 0;
        isPlayer2count = 0;
        for (int i = 0; i < ps.Length; i++)
        {   
            if (ps[i].isPlayer1)
            {
                isPlayer1count++;
            }
            else
            {
                isPlayer2count++;
            }
        }
        if (isPlayer1count==0)
        {
            Victory(false);
        }
        if (isPlayer2count==0)
        {
            Victory(true);
        }
       
    }
    public void draw()
    {
        Handheld.Vibrate();
        Debug.Log("draw");
        Draw.active = true;
    }
    private List<Piece> ScanForPossibleMove()
    {
        forcedPieces = new List<Piece>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Pieces[i,j]!=null&&Pieces[i,j].isPlayer1==isPlayer1Turn)
                {
                    if (Pieces[i,j].isForceToMove(Pieces,i,j))
                    {
                        forcedPieces.Add(Pieces[i, j]);
                    }
                }
            }
        }
        return forcedPieces;
    }
    //private List<Piece> DrawCheck(Piece p, int x, int y)
    //{
    //    BlockedPieces = new List<Piece>();
    //    for (int i = 0; i < 8; i++)
    //    {
    //        for (int j = 0; j < 8; j++)
    //        {
    //        }
    //    }

    //            return forcedPieces;
    //}
    private List<Piece> DrawCheck()
    {
        BlockedPieces = new List<Piece>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Pieces[i, j] != null && Pieces[i, j].isPlayer1 == isPlayer1Turn)
                {
                    if (Pieces[i, j].BlockChecker(Pieces, i, j))
                    {
                        BlockedPieces.Add(Pieces[i, j]);
                    }
                }
            }
        }
        return BlockedPieces;
    }
    private void Victory(bool isPlayer1)
    {
        if(!isPlayer1)
        {
            Handheld.Vibrate();
            Debug.Log("Black won");
            Win.active = true;

            Win.GetComponent<TextMeshProUGUI>().text = "Black Won\n Your Score:"+scorecount2;
        }
        else
        {
            Handheld.Vibrate();
          
            Debug.Log("White won");
            Win.active = true;
            Win.GetComponent<TextMeshProUGUI>().text = "White\n Your Score:" + scorecount1;

        }
        vib = true;
        isWin = true;
    }
    private void UpdatePieceDrag(Piece p)
    {
        RaycastHit hit;
        if (!Camera.main)
        {
            return;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            p.transform.position = hit.point ;
        }

    }
    private void SelectPiece(int x, int y)
    {
        if(x<0||x>8|| y < 0 || y > 8)
        {
            return;
        }
        Piece p = Pieces[x, y];
            if(p!=null&&p.isPlayer1==isPlayer1)
            {
            if (forcedPieces.Count==0)
            {


                selectedPiece = p;
                startDrag = Mouse;
            }
            else
            {
                if(forcedPieces.Find(fp=>fp==p)==null)
                {
                   
                    return;
                    
                }
                selectedPiece = p;
                startDrag = Mouse;
            }
            //Debug.Log(selectedPiece.name);
            //Debug.Log(x);
            //Debug.Log(y);
        }
    }
    private void MouseUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Board")))
        {
            Mouse.x = (int)(hit.point.x-boardOffset.x);
            Mouse.y = (int)(hit.point.y-boardOffset.y);
        }
        else
        {
            Mouse.x = -1;
            Mouse.y = -1;
        }
    }
    private void GenerateBoard()
    {
        for (int y = 0; y < 3; y++)
        {
            bool OddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                GeneratePiece((OddRow) ? x : x + 1, y);
            }
        }
        for (int y = 5; y < 8; y++)
        {
            bool OddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                GeneratePiece((OddRow) ? x : x + 1, y);
            }
        }
    }
    private void GeneratePiece(int x, int y)
    {
        bool isPlayer1 = (y > 3) ? false:true;
        GameObject go = Instantiate((isPlayer1) ? player1Prefab:player2Prefab) as GameObject;
        go.transform.SetParent(transform);
        Piece p = go.GetComponent<Piece>();
        Pieces[x, y] = p;
        MovePieces(p, x, y);
    }
    private void MovePieces(Piece p, int x, int y)
    {
        p.transform.position = (Vector2.right*(x))+(Vector2.up*(y))+boardOffset+pieceOffset;
    }
}
