using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public bool isPlayer1;
    public bool isKing;
    public bool BlockChecker(Piece[,] board, int x, int y)
    {
        if (isPlayer1&&!isKing)
        {
            int trigger2 = 0;
            if (x >= 1 && x <= 6 && y <= 6)
            {


                int trigger1 = 0;
              
                Piece p1 = board[x - 1, y + 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x - 2, y + 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }

                Piece p2 = board[x + 1, y + 1];
                if (p2 != null)
                {
                    try
                    {
                        if (board[x + 2, y + 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p2.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }

                    }
                    catch (System.Exception)
                    {
                        if (p2.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 2)
                {
                    return true;
                }
            }
            if (x == 0 && y <= 6)
            {
                int trigger1 = 0;
               
                Piece p1 = board[x + 1, y + 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x + 2, y + 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 1)
                {
                    return true;
                }
            }
            if (x == 7 && y <= 6)
            {
                int trigger1 = 0;
                
                Piece p1 = board[x - 1, y + 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x - 2, y + 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 1)
                {
                    return true;
                }
            }
        }
        if (!isPlayer1&&!isKing)
        {
            if (x >= 1 && x <= 6 && y >= 1)
            {


                int trigger1 = 0;
                int trigger2 = 0;
                Piece p1 = board[x - 1, y - 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x - 2, y - 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }

                Piece p2 = board[x + 1, y - 1];
                if (p2 != null)
                {
                    try
                    {
                        if (board[x + 2, y - 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p2.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }

                    }
                    catch (System.Exception)
                    {
                        if (p2.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 2)
                {
                    return true;
                }
            }
            if (x == 0 && y >= 1)
            {
                int trigger1 = 0;
                int trigger2 = 0;
                Piece p1 = board[x + 1, y - 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x + 2, y - 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 1)
                {
                    return true;
                }
            }
            if (x == 7 && y >= 1)
            {
                int trigger1 = 0;
                int trigger2 = 0;
                Piece p1 = board[x - 1, y - 1];
                if (p1 != null)
                {
                    try
                    {
                        if (board[x - 2, y - 2] != null)
                        {
                            trigger1++;
                            trigger2++;
                        }
                        else if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }
                    catch (System.Exception)
                    {
                        if (p1.isPlayer1 == isPlayer1)
                        {
                            trigger1++;
                            trigger2++;
                        }
                    }

                }
                if (trigger1 == 1)
                {
                    return true;
                }
            }
        }





        //if (isPlayer1)
        //{
        //    if (x >= 2 && x <= 5 && y <= 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y + 1];
        //        if (p1!=null)
        //        {
        //            if (board[x - 2, y + 2] != null || p1.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x + 1, y + 1];
        //        if (p2 != null)
        //        {
        //            if (board[x + 2, y + 2] != null || p2.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }   
        //    if (x==1&&y<6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y + 1];
        //        if (p1 != null)
        //        {
        //            if (board[x + 2, y + 2] != null || p1.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x - 1, y + 1];
        //        if(p2 != null)
        //        {
        //            trigger1++;
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 5 && y < 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y + 1];
        //        if (p1 != null)
        //        {
        //            if (board[x - 2, y + 2] != null || p1.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x + 1, y + 1];
        //        if (p2 != null )
        //        {
        //            trigger1++;
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 0 && y < 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y + 1];
        //        if (p1 != null )
        //        {
        //            if (board[x + 2, y + 2] != null || p1.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }

        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 7 && y < 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y + 1];
        //        if (p1 != null )
        //        {
        //            if (board[x - 2, y + 2] != null || p1.isPlayer1 != isPlayer1)
        //            {
        //                trigger1++;
        //            }
        //        }

        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x > 0 && y == 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y + 1];
        //        if (p1 != null)
        //        {

        //                trigger1++;

        //        }
        //        Piece p2 = board[x - 1, y + 1];
        //        if (p2 != null )
        //        {

        //            trigger1++;

        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 0 && y == 6)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y + 1];
        //        if (p1 != null )
        //        {

        //            trigger1++;

        //        }
        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }
        //}
        //if (!isPlayer1)
        //{
        //    if (x >= 2 && x <= 5 && y >= 2)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y - 1];
        //        if (p1 != null )
        //        {
        //            if (board[x - 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x + 1, y - 1];
        //        if (p2 != null)
        //        {
        //            if (board[x + 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 1 && y > 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y - 1];
        //        if (p1 != null )
        //        {
        //            if (board[x + 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x - 1, y - 1];
        //        if (p2 != null )
        //        {
        //            trigger1++;
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 5 && y > 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y - 1];
        //        if (p1 != null )
        //        {
        //            if (board[x - 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }
        //        Piece p2 = board[x + 1, y - 1];
        //        if (p2 != null )
        //        {
        //            trigger1++;
        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 0 && y > 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y - 1];
        //        if (p1 != null )
        //        {
        //            if (board[x + 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }

        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 7 && y < 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x - 1, y - 1];
        //        if (p1 != null )
        //        {
        //            if (board[x - 2, y - 2] != null)
        //            {
        //                trigger1++;
        //            }
        //        }

        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x < 7 && y == 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y - 1];
        //        if (p1 != null)
        //        {

        //            trigger1++;

        //        }
        //        Piece p2 = board[x - 1, y + 1];
        //        if (p2 != null )
        //        {

        //            trigger1++;

        //        }
        //        if (trigger1 == 2)
        //        {
        //            return true;
        //        }
        //    }
        //    if (x == 7 && y == 1)
        //    {
        //        int trigger1 = 0;
        //        Piece p1 = board[x + 1, y - 1];
        //        if (p1 != null)
        //        {

        //            trigger1++;

        //        }
        //        if (trigger1 == 1)
        //        {
        //            return true;
        //        }
        //    }

        //}
        return false;
    }
    public bool isForceToMove(Piece[,] board, int x, int y)
    {
        //if (isPlayer1||isKing)
        {
            if (x >= 2 && y <= 5)
            {
                Piece p = board[x - 1, y + 1];
                if (p!=null&&p.isPlayer1!=isPlayer1)
                {
                    if (board[x - 2, y + 2] == null)
                    {
                        return true;
                    }
                }
                
            }
            if (x <= 5 && y <= 5)
            {
                Piece p = board[x + 1, y + 1];
                if (p != null && p.isPlayer1 != isPlayer1)
                {
                    if (board[x + 2, y + 2] == null)
                    {
                        return true;
                    }
                }

            }
        }
        //if(!isPlayer1||isKing)
        {

            if (x >= 2 && y >= 2)
            {
                Piece p = board[x - 1, y - 1];
                if (p != null && p.isPlayer1 != isPlayer1)
                {
                    if (board[x - 2, y - 2] == null)
                    {
                        return true;
                    }
                }

            }
            if (x <= 5 && y >= 2)
            {
                Piece p = board[x + 1, y - 1];
                if (p != null && p.isPlayer1 != isPlayer1)
                {
                    if (board[x + 2, y - 2] == null)
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }
    public bool ValidMove(Piece[,] board, int x1, int y1, int x2, int y2)
    {
        if (board[x2,y2]!=null)
        {
            return false;
        }
        int deltaMove = Mathf.Abs(x1 - x2);
        int deltaMoveY =y2 - y1;
//        if (isKing||isPlayer1)
        {
            if (deltaMove==1&&(isKing || isPlayer1))
            {
                if (deltaMoveY==1)
                {
                    return true;
                }
            }
            else if(deltaMove==2)
            {
                if (deltaMoveY==2)
                {
                    Piece p = board[(x1 + x2) / 2, (y1 + y2) / 2];
                    if (p!=null&&p.isPlayer1!=isPlayer1)
                    {
                        return true;
                    }
                }
            }
        }
  //      if (isKing || !isPlayer1)
        {
            if (deltaMove == 1 && (isKing || !isPlayer1))
            {
                if (deltaMoveY == -1)
                {
                    return true;
                }
            }
            else if (deltaMove == 2)
            {
                if (deltaMoveY == -2)
                {
                    Piece p = board[(x1 + x2) / 2, (y1 + y2) / 2];
                    if (p != null && p.isPlayer1 != isPlayer1)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
