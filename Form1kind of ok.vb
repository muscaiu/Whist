Public Class Form1
    Dim TotalPlayers As Integer
    Dim Player1Name As String = "Player1"
    Dim Player2Name As String = "Player2"
    Dim Player3Name As String = "Player3"
    Dim Player4Name As String = "Player4"
    Dim Player5Name As String = "Player5"
    Dim Player6Name As String = "Player6"

    Dim CurrentPlayer As String = "Waiting info Current Player ..."
    Dim NextPlayer As String = "Waiting info Next Player ..."
    Dim CurrentDealer As String = "Waiting info Dealer ..."
    Dim row As Integer = 1

    Dim myBid As Integer
    Dim endBid As Integer
    Dim TotalBids As Integer
    Dim TotalEnds As Integer

    'Declare Boolean Values
    Dim BidRound As Boolean = True
    Dim EndRound As Boolean = False
    Dim PunctajNormal As Boolean = False
    Dim PunctajProgresiv As Boolean = False
    Dim GameON As Boolean = False
    Dim DubluPunctaj As Boolean = False
    Dim CuPremiere As Boolean = False

    'Declare Queues
    Dim d As New Queue()
    Dim c As New Queue()
    Dim nextP As New Queue()

    Dim Table1x8x1 As Boolean = False
    Dim Table8x1x8 As Boolean = False

    'Holds cRound Values
    Dim cRoundValuesx4x1() As Integer = {1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1}
    Dim cRoundValuesx5x1() As Integer = {1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1}
    Dim cRoundValuesx6x1() As Integer = {1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1}
    Dim cRoundValuesx5x8() As Integer = {8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8}
    Dim cRoundValuesx4x8() As Integer = {8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8}
    Dim cRoundValuesx6x8() As Integer = {8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8}
    Dim cRoundIndex As Integer
    Dim cRound As Integer = 1
    'Increments cRoundValuesx4x1 , cRoundValuesx4x8, cRoundValuesx5x1, cRoundValuesx5x8, cRoundValuesx6x1, cRoundValuesx6x8
    Public Sub IncrementcRoundIndexX4x1(ByVal x As Integer)
        cRound = cRoundValuesx4x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx4x1.Length Then cRoundIndex = 0
    End Sub
    Public Sub IncrementcRoundIndexX4x8(ByVal x As Integer)
        cRound = cRoundValuesx4x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx4x8.Length Then cRoundIndex = 0
    End Sub
    Public Sub IncrementcRoundIndexX5x1(ByVal x As Integer)
        cRound = cRoundValuesx5x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx5x1.Length Then cRoundIndex = 0
    End Sub
    Public Sub IncrementcRoundIndexX5x8(ByVal x As Integer)
        cRound = cRoundValuesx5x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx5x8.Length Then cRoundIndex = 0
    End Sub
    Public Sub IncrementcRoundIndexX6x1(ByVal x As Integer)
        cRound = cRoundValuesx6x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx6x1.Length Then cRoundIndex = 0
    End Sub
    Public Sub IncrementcRoundIndexX6x8(ByVal x As Integer)
        cRound = cRoundValuesx6x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1 'rest is for End Game
        If cRoundIndex = cRoundValuesx6x8.Length Then cRoundIndex = 0
    End Sub

    'Queue Current Player
    Private Sub QueueCurrentAndNextPlayer()
        If TotalPlayers = 4 Then
            CurrentPlayerx4()
            NextPlayerx4()
        ElseIf TotalPlayers = 5 Then
            CurrentPlayerx5()
            NextPlayerx5()
        ElseIf TotalPlayers = 6 Then
            CurrentPlayerx6()
            NextPlayerx6()
        End If
    End Sub

    'Curent Player x4
    Private Sub CurrentPlayerx4()
        c.Enqueue(Player1Name)
        c.Enqueue(Player2Name)
        c.Enqueue(Player3Name)
        c.Enqueue(Player4Name)
        CurrentPlayer = c.Peek()
        lblPlayer.Text = "CurrentPlayer: " & CurrentPlayer
    End Sub
    Private Sub CurrentPlayerx5()
        c.Enqueue(Player1Name)
        c.Enqueue(Player2Name)
        c.Enqueue(Player3Name)
        c.Enqueue(Player4Name)
        c.Enqueue(Player5Name)
        CurrentPlayer = c.Peek()
        lblPlayer.Text = "CurrentPlayer: " & CurrentPlayer
    End Sub
    Private Sub CurrentPlayerx6()
        c.Enqueue(Player1Name)
        c.Enqueue(Player2Name)
        c.Enqueue(Player3Name)
        c.Enqueue(Player4Name)
        c.Enqueue(Player5Name)
        c.Enqueue(Player6Name)
        CurrentPlayer = c.Peek()
        lblPlayer.Text = "CurrentPlayer: " & CurrentPlayer
    End Sub

    'Next Player x4
    Private Sub NextPlayerx4()
        nextP.Enqueue(Player2Name)
        nextP.Enqueue(Player3Name)
        nextP.Enqueue(Player4Name)
        nextP.Enqueue(Player1Name)
        NextPlayer = nextP.Peek()
        lblNextPlayer.Text = "Next Player: " & NextPlayer
    End Sub
    Private Sub NextPlayerx5()
        nextP.Enqueue(Player2Name)
        nextP.Enqueue(Player3Name)
        nextP.Enqueue(Player4Name)
        nextP.Enqueue(Player5Name)
        nextP.Enqueue(Player1Name)
        NextPlayer = nextP.Peek()
        lblNextPlayer.Text = "Next Player: " & NextPlayer
    End Sub
    Private Sub NextPlayerx6()
        nextP.Enqueue(Player2Name)
        nextP.Enqueue(Player3Name)
        nextP.Enqueue(Player4Name)
        nextP.Enqueue(Player5Name)
        nextP.Enqueue(Player6Name)
        nextP.Enqueue(Player1Name)
        NextPlayer = nextP.Peek()
        lblNextPlayer.Text = "Next Player: " & NextPlayer
    End Sub

    'Dealer Turn Queue
    Private Sub DealerTurnx4()
        d.Enqueue(Player4Name)
        d.Enqueue(Player1Name)
        d.Enqueue(Player2Name)
        d.Enqueue(Player3Name)
        CurrentDealer = d.Peek()
        lblDealer.Text = ("Dealer: " & CurrentDealer)
    End Sub
    Private Sub DealerTurnx5()
        d.Enqueue(Player5Name)
        d.Enqueue(Player1Name)
        d.Enqueue(Player2Name)
        d.Enqueue(Player3Name)
        d.Enqueue(Player4Name)
        CurrentDealer = d.Peek()
        lblDealer.Text = ("Dealer: " & CurrentDealer)
    End Sub
    Private Sub DealerTurnx6()
        d.Enqueue(Player6Name)
        d.Enqueue(Player1Name)
        d.Enqueue(Player2Name)
        d.Enqueue(Player3Name)
        d.Enqueue(Player4Name)
        d.Enqueue(Player5Name)
        CurrentDealer = d.Peek()
        lblDealer.Text = ("Dealer: " & CurrentDealer)
    End Sub

    'Check how manny total players and Check if all Bided then disable bid buttons
    Private Sub IfAllBidDisableBids()
        If TotalPlayers = 4 Then
            If BidRound = True And Player1HasBided() And Player2HasBided() And Player3HasBided() And Player4HasBided() = True Then
                DisableAllBids()
                btnEndRoundScore.Enabled = True
            End If

            If EndRound = True And Player1HasEnded() And Player2HasEnded() And Player3HasEnded() And Player4HasEnded() Then
                DisableAllBids()
                btnUpdScore.Enabled = True
            End If
        End If
        If TotalPlayers = 5 Then
            If BidRound = True And Player1HasBided() And Player2HasBided() And Player3HasBided() And Player4HasBided() And Player5HasBided() = True Then
                DisableAllBids()
                btnEndRoundScore.Enabled = True
            End If

            If EndRound = True And Player1HasEnded() And Player2HasEnded() And Player3HasEnded() And Player4HasEnded() And Player5HasEnded() Then
                DisableAllBids()
                btnUpdScore.Enabled = True
            End If
        End If
        If TotalPlayers = 6 Then
            If BidRound = True And Player1HasBided() And Player2HasBided() And Player3HasBided() And Player4HasBided() And Player5HasBided() And Player6HasBided() = True Then
                DisableAllBids()
                btnEndRoundScore.Enabled = True
            End If

            If EndRound = True And Player1HasEnded() And Player2HasEnded() And Player3HasEnded() And Player4HasEnded() And Player5HasEnded() And Player6HasEnded() Then
                DisableAllBids()
                btnUpdScore.Enabled = True
            End If
        End If
    End Sub

    'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
    Private Sub DealerFaraX()

        If BidRound = True Then
            '''''IF Round = 1 Obigate Dealer
            If cRound = 1 Then
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 2 Obigate Dealer
            If cRound = 2 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If

                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF ROund = 3 Obigate Dealer
            If cRound = 3 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 4 Obigate Dealer
            If cRound = 4 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn4.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 4!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 5 Obigate Dealer
            If cRound = 5 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn5.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 5!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn4.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 4!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 6 Obigate Dealer
            If cRound = 6 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn6.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 6!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn5.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 5!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn4.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 4!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 7 Obigate Dealer
            If cRound = 7 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn7.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 7!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn6.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 6!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn5.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 5!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn4.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 4!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 7 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 8 Obigate Dealer
            If cRound = 8 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn8.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 8!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn7.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 7!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn6.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 6!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn5.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 5!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn4.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 4!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn3.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 3!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn2.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 2!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 7 Then
                    btn1.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 1!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 8 Then
                    btn0.Enabled = False
                    ListBox1.Items.Add(CurrentDealer & " fara 0!")
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                End If
            End If
        End If

    End Sub

    'Enable Bid Buttons Subs to be used in ifRoundEnableButtons
    Private Sub enableBidRound1()
        btn0.Enabled = True
        btn1.Enabled = True
    End Sub
    Private Sub enableBidRound2()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
    End Sub
    Private Sub enableBidRound3()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
    End Sub
    Private Sub enableBidRound4()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
    End Sub
    Private Sub enableBidRound5()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
    End Sub
    Private Sub enableBidRound6()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
    End Sub
    Private Sub enableBidRound7()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn7.Enabled = True
    End Sub
    Private Sub enableBidRound8()
        btn0.Enabled = True
        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn7.Enabled = True
        btn8.Enabled = True
    End Sub
    'Disable All Bids
    Public Sub DisableAllBids()
        btn0.Enabled = False
        btn1.Enabled = False
        btn2.Enabled = False
        btn3.Enabled = False
        btn4.Enabled = False
        btn5.Enabled = False
        btn6.Enabled = False
        btn7.Enabled = False
        btn8.Enabled = False
    End Sub
    'If the current round is x then enable only available buttons
    Public Sub ifRoundEnableButton()
        If cRound = 1 Then
            enableBidRound1()
        End If
        If cRound = 2 Then
            enableBidRound2()
        End If
        If cRound = 3 Then
            enableBidRound3()
        End If
        If cRound = 4 Then
            enableBidRound4()
        End If
        If cRound = 5 Then
            enableBidRound5()
        End If
        If cRound = 6 Then
            enableBidRound6()
        End If
        If cRound = 7 Then
            enableBidRound7()
        End If
        If cRound = 8 Then
            enableBidRound8()
        End If
    End Sub

    'Check if Players have bided condition TRUE OR FALSE
    Public Function Player1HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(2).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    Public Function Player2HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(5).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    Public Function Player3HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(8).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    Public Function Player4HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(11).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    Public Function Player5HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(14).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    Public Function Player6HasBided() As Boolean
        Dim HasBided As Boolean
        If dgv1.Rows(row).Cells(17).Value Is Nothing Then
            HasBided = False
        Else
            HasBided = True
        End If
        Return HasBided
    End Function
    'Check if Players have Ended
    Public Function Player1HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(3).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function
    Public Function Player2HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(6).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function
    Public Function Player3HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(9).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function
    Public Function Player4HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(12).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function
    Public Function Player5HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(15).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function
    Public Function Player6HasEnded() As Boolean
        Dim HasEnded As Boolean
        If dgv1.Rows(row).Cells(18).Value Is Nothing Then
            HasEnded = False
        Else
            HasEnded = True
        End If
        Return HasEnded
    End Function

    'Check TotalBid for CurrentDealer
    Public Sub CheckTotalBid()
        If TotalPlayers = 4 And BidRound = True Then
            Dim P1Bid = dgv1.Rows(row).Cells(2).Value
            Dim P2Bid = dgv1.Rows(row).Cells(5).Value
            Dim P3Bid = dgv1.Rows(row).Cells(8).Value
            Dim P4Bid = dgv1.Rows(row).Cells(11).Value
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Red
        End If
        If TotalPlayers = 5 And BidRound = True Then
            Dim P1Bid = dgv1.Rows(row).Cells(2).Value
            Dim P2Bid = dgv1.Rows(row).Cells(5).Value
            Dim P3Bid = dgv1.Rows(row).Cells(8).Value
            Dim P4Bid = dgv1.Rows(row).Cells(11).Value
            Dim P5Bid = dgv1.Rows(row).Cells(14).Value
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid + P5Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Red
        End If
        If TotalPlayers = 6 And BidRound = True Then
            Dim P1Bid = dgv1.Rows(row).Cells(2).Value
            Dim P2Bid = dgv1.Rows(row).Cells(5).Value
            Dim P3Bid = dgv1.Rows(row).Cells(8).Value
            Dim P4Bid = dgv1.Rows(row).Cells(11).Value
            Dim P5Bid = dgv1.Rows(row).Cells(14).Value
            Dim P6Bid = dgv1.Rows(row).Cells(17).Value
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid + P5Bid + P6Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Red
        End If
        If TotalPlayers = 4 And EndRound = True Then
            Dim P1End = dgv1.Rows(row).Cells(3).Value
            Dim P2End = dgv1.Rows(row).Cells(6).Value
            Dim P3End = dgv1.Rows(row).Cells(9).Value
            Dim P4End = dgv1.Rows(row).Cells(12).Value
            TotalEnds = P1End + P2End + P3End + P4End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Blue
        End If
        If TotalPlayers = 5 And EndRound = True Then
            Dim P1End = dgv1.Rows(row).Cells(3).Value
            Dim P2End = dgv1.Rows(row).Cells(6).Value
            Dim P3End = dgv1.Rows(row).Cells(9).Value
            Dim P4End = dgv1.Rows(row).Cells(12).Value
            Dim P5End = dgv1.Rows(row).Cells(15).Value
            TotalEnds = P1End + P2End + P3End + P4End + P5End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Blue
        End If
        If TotalPlayers = 6 And EndRound = True Then
            Dim P1End = dgv1.Rows(row).Cells(3).Value
            Dim P2End = dgv1.Rows(row).Cells(6).Value
            Dim P3End = dgv1.Rows(row).Cells(9).Value
            Dim P4End = dgv1.Rows(row).Cells(12).Value
            Dim P5End = dgv1.Rows(row).Cells(15).Value
            Dim P6End = dgv1.Rows(row).Cells(18).Value
            TotalEnds = P1End + P2End + P3End + P4End + P5End + P6End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Blue
        End If
    End Sub

    'Add Listbox Messages
    Private Sub ListboxMsg()
        If BidRound = True And CurrentPlayer <> CurrentDealer Then
            ListBox1.Items.Add("Liciteaza " & NextPlayer)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
        End If
        If EndRound = True Then
            ListBox1.Items.Add("Cate a facut " & NextPlayer & " ?")
            ListBox1.TopIndex = ListBox1.Items.Count - 1
        End If
    End Sub

    'AddMybid 
    Private Sub AddMyBid()
        If CurrentPlayer = Player1Name Then
            dgv1.Rows(row).Cells(2).Value = myBid
            dgv1.Rows(row).Cells(2).ToolTipText = (Player1Name & " a zis " & myBid)
        ElseIf CurrentPlayer = Player2Name Then
            dgv1.Rows(row).Cells(5).Value = myBid
            dgv1.Rows(row).Cells(5).ToolTipText = (Player2Name & " a zis " & myBid)
        ElseIf CurrentPlayer = Player3Name Then
            dgv1.Rows(row).Cells(8).Value = myBid
            dgv1.Rows(row).Cells(8).ToolTipText = (Player3Name & " a zis " & myBid)
        ElseIf CurrentPlayer = Player4Name Then
            dgv1.Rows(row).Cells(11).Value = myBid
            dgv1.Rows(row).Cells(11).ToolTipText = (Player4Name & " a zis " & myBid)
        ElseIf CurrentPlayer = Player5Name Then
            dgv1.Rows(row).Cells(14).Value = myBid
            dgv1.Rows(row).Cells(14).ToolTipText = (Player5Name & " a zis " & myBid)
        ElseIf CurrentPlayer = Player6Name Then
            dgv1.Rows(row).Cells(17).Value = myBid
            dgv1.Rows(row).Cells(17).ToolTipText = (Player6Name & " a zis " & myBid)
        End If
    End Sub
    'AddEndBid
    Private Sub AddEndBid()
        If CurrentPlayer = Player1Name Then
            dgv1.Rows(row).Cells(3).Value = endBid
            dgv1.Rows(row).Cells(3).ToolTipText = (Player1Name & " a facut " & endBid)
        ElseIf CurrentPlayer = Player2Name Then
            dgv1.Rows(row).Cells(6).Value = endBid
            dgv1.Rows(row).Cells(6).ToolTipText = (Player2Name & " a facut " & endBid)
        ElseIf CurrentPlayer = Player3Name Then
            dgv1.Rows(row).Cells(9).Value = endBid
            dgv1.Rows(row).Cells(9).ToolTipText = (Player3Name & " a facut " & endBid)
        ElseIf CurrentPlayer = Player4Name Then
            dgv1.Rows(row).Cells(12).Value = endBid
            dgv1.Rows(row).Cells(12).ToolTipText = (Player4Name & " a facut " & endBid)
        ElseIf CurrentPlayer = Player5Name Then
            dgv1.Rows(row).Cells(15).Value = endBid
            dgv1.Rows(row).Cells(15).ToolTipText = (Player5Name & " a facut " & endBid)
        ElseIf CurrentPlayer = Player6Name Then
            dgv1.Rows(row).Cells(18).Value = endBid
            dgv1.Rows(row).Cells(18).ToolTipText = (Player6Name & " a facut " & endBid)
        End If
    End Sub


    'btn0
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()

        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 0
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        End If
        If EndRound = True Then
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 0
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn1
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        'Loop Current and Next Player Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 1
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        End If
        If EndRound = True Then
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 1
            AddEndBid()
        End If

        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn2
    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 2
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 2
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn3
    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 3
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 3
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn4
    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 4
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 4
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn5
    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 5
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 5
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn6
    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 6
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 6
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn7
    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 7
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 7
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
    'btn8
    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        'Loop Current Player
        QueueCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 8
            ListBox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            AddMyBid()
        Else
            ListBox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
            endBid = 8
            AddEndBid()
        End If
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        c.Dequeue()
        nextP.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid()
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub


    'ScorP1
    Public Function ScorP1() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(2).Value 'Licitat value
        Dim E1 As Integer = dgv1.Rows(row).Cells(3).Value 'Cate a facut value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(1).Value 'Cate puncte avea jocul trecut
        Dim D1 As Integer = Math.Abs(L1 - E1) 'difference of bid must be always possitive
        Dim T1 As Integer 'totaL score
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If
        'if difference of bid is 0 then 
        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

            Return T1
    End Function
    'ScorP2
    Public Function ScorP2() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(5).Value
        Dim E1 As Integer = dgv1.Rows(row).Cells(6).Value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(4).Value
        Dim D1 As Integer = Math.Abs(L1 - E1)
        Dim T1 As Integer
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca a selectat punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If

        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

        Return T1
    End Function
    'ScorP3
    Public Function ScorP3() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(8).Value
        Dim E1 As Integer = dgv1.Rows(row).Cells(9).Value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(7).Value
        Dim D1 As Integer = Math.Abs(L1 - E1)
        Dim T1 As Integer
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca a selectat punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If

        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

        Return T1
    End Function
    'ScorP4
    Public Function ScorP4() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(11).Value
        Dim E1 As Integer = dgv1.Rows(row).Cells(12).Value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(10).Value
        Dim D1 As Integer = Math.Abs(L1 - E1)
        Dim T1 As Integer
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca a selectat punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If

        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

        Return T1
    End Function
    'ScorP5R1
    Public Function ScorP5() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(14).Value
        Dim E1 As Integer = dgv1.Rows(row).Cells(15).Value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(13).Value
        Dim D1 As Integer = Math.Abs(L1 - E1)
        Dim T1 As Integer
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca a selectat punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If

        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

        Return T1
    End Function
    'ScorP6R1
    Public Function ScorP6() As Integer
        Dim L1 As Integer = dgv1.Rows(row).Cells(17).Value
        Dim E1 As Integer = dgv1.Rows(row).Cells(18).Value
        Dim PL As Integer = dgv1.Rows(row - 1).Cells(16).Value
        Dim D1 As Integer = Math.Abs(L1 - E1)
        Dim T1 As Integer
        Dim Pro As Integer
        Dim D1Pro As Integer

        If PunctajProgresiv = True Then 'Daca a selectat punctajprogresiv modifica valorile L1 si D1
            If L1 = 0 Then Pro = 0
            If L1 = 1 Then Pro = 1
            If L1 = 2 Then Pro = 3
            If L1 = 3 Then Pro = 6
            If L1 = 4 Then Pro = 10
            If L1 = 5 Then Pro = 15
            If L1 = 6 Then Pro = 21
            If L1 = 7 Then Pro = 28
            If L1 = 8 Then Pro = 36

            If D1 = 0 Then D1Pro = 0
            If D1 = 1 Then D1Pro = 1
            If D1 = 2 Then D1Pro = 3
            If D1 = 3 Then D1Pro = 6
            If D1 = 4 Then D1Pro = 10
            If D1 = 5 Then D1Pro = 15
            If D1 = 6 Then D1Pro = 21
            If D1 = 7 Then D1Pro = 28
            If D1 = 8 Then D1Pro = 36
        End If

        If D1 = 0 Then
            If DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                T1 = PL + (Pro + 5) * 2
            Else
                T1 = PL + L1 + 5
            End If
            'Total is Old Points + Bid + 5

        ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
            'subtract difference from score
            T1 = PL - D1Pro
        ElseIf D1 <> 0 Then
            T1 = PL - D1
        End If

        Return T1
    End Function

    'Disable DGV Selection by Changing Fore and back Colors
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.SelectionChanged
        If dgv1.SelectedCells.Count > 0 Then
            dgv1.ClearSelection()
        End If
    End Sub

    '<DISABLED FOR NOW> Change DGV Header colors
    Private Sub ChangeDgvHeaderColors()
        'Disable DGV Header Visual Style in order to change it's Colors
        Me.dgv1.EnableHeadersVisualStyles = False
        'Change DGV Header colors
        Me.dgv1.Columns(0).HeaderCell.Style.BackColor = Color.White
        Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.MediumSpringGreen
        Me.dgv1.Columns(2).HeaderCell.Style.BackColor = Color.MediumSpringGreen
        Me.dgv1.Columns(3).HeaderCell.Style.BackColor = Color.MediumSpringGreen
        Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Gold
        Me.dgv1.Columns(5).HeaderCell.Style.BackColor = Color.Gold
        Me.dgv1.Columns(6).HeaderCell.Style.BackColor = Color.Gold
        Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Crimson
        Me.dgv1.Columns(8).HeaderCell.Style.BackColor = Color.Crimson
        Me.dgv1.Columns(9).HeaderCell.Style.BackColor = Color.Crimson
        Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.DodgerBlue
        Me.dgv1.Columns(11).HeaderCell.Style.BackColor = Color.DodgerBlue
        Me.dgv1.Columns(12).HeaderCell.Style.BackColor = Color.DodgerBlue
        Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Orange
        Me.dgv1.Columns(14).HeaderCell.Style.BackColor = Color.Orange
        Me.dgv1.Columns(15).HeaderCell.Style.BackColor = Color.Orange
        Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.HotPink
        Me.dgv1.Columns(14).HeaderCell.Style.BackColor = Color.HotPink
        Me.dgv1.Columns(15).HeaderCell.Style.BackColor = Color.HotPink



    End Sub
    'FormLoad
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        'Center DGV HeaderText
        For centerHeaderText As Integer = 0 To 18
            dgv1.Columns(centerHeaderText).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        Next centerHeaderText

        'Make all labels invisible
        PanelLables.Visible = False

        'Disable: EndRoundScore, UpdateScore, StartNextRound, EnterPlayerNAmes, GroupBox1
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        btnStartNextRound.Enabled = False
        GroupBox1.Visible = False
        GroupBox1.Enabled = False
        Panel5.Visible = False
        dgv1.Visible = False
        'btnPunctajNormal.Visible = False
        'btnPunctajProgresiv.Visible = False

        'adding 1-st Score ROW
        dgv1.Rows.Add(0, "invisible")
        dgv1.Rows(0).Visible = False
        dgv1.Rows(0).Cells(1).Value = 0
        dgv1.Rows(0).Cells(4).Value = 0
        dgv1.Rows(0).Cells(7).Value = 0
        dgv1.Rows(0).Cells(10).Value = 0
        dgv1.Rows(0).Cells(13).Value = 0
        dgv1.Rows(0).Cells(16).Value = 0
        'Welcome Messages In System Window
        ListBox1.Items.Add("Game Setup")
        ListBox1.Items.Add(".....................")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub

    'btnStartNextRound
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartNextRound.Click
        'Update Labels
        lblRow.Text = "Current Row: " & row
        lblRound.Text = "Current Round: " & cRound
        ListBox1.Items.Add("+++ Bid Round " & row & " +++")
        ListBox1.Items.Add(".....................")
        ListBox1.TopIndex = ListBox1.Items.Count - 1

        'Check Total Number of Players and Loop Players and Dealer
        If TotalPlayers = 4 Then
            CurrentPlayerx4()
            NextPlayerx4()
            DealerTurnx4()
        ElseIf TotalPlayers = 5 Then
            CurrentPlayerx5()
            NextPlayerx5()
            DealerTurnx5()
        ElseIf TotalPlayers = 6 Then
            CurrentPlayerx6()
            NextPlayerx6()
            DealerTurnx6()
        End If

        'Enable: GroupBox 'Disable: StartNextRound
        GroupBox1.Enabled = True
        btnStartNextRound.Enabled = False

        'Increments cRound Values depending on TotalPlayers and Selected Table
        If TotalPlayers = 4 Then
            If Table1x8x1 = True Then
                IncrementcRoundIndexX4x1(cRound)
            End If
            If Table8x1x8 = True Then
                IncrementcRoundIndexX4x8(cRound)
            End If

        End If
        If TotalPlayers = 5 Then
            If Table1x8x1 = True Then
                IncrementcRoundIndexX5x1(cRound)
            End If
            If Table8x1x8 = True Then
                IncrementcRoundIndexX5x8(cRound)
            End If

        End If
        If TotalPlayers = 6 Then
            If Table1x8x1 = True Then
                IncrementcRoundIndexX6x1(cRound)
            End If
            If Table8x1x8 = True Then
                IncrementcRoundIndexX6x8(cRound)
            End If
        End If
        'Add a Row and cRound Value in 1-st column
        dgv1.Rows.Add()
        dgv1.Rows(row).Cells(0).Value = cRound

        'Diable all button bids and Enable only those for current Round
        DisableAllBids()
        ifRoundEnableButton()
        'Declare BidRound True and EndRound False
        BidRound = True
        EndRound = False
        'System Window Message for Start Bid
        ListBox1.Items.Add("Liciteaza " & CurrentPlayer)
        ListBox1.TopIndex = ListBox1.Items.Count - 1
        lblcRoundindex.Text = ("cRoundIndex: " & cRoundIndex)

    End Sub

    'btnEndRound
    Private Sub btnEndRoundScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndRoundScore.Click
        'Check Total Number of Players and Loop Players and Dealer
        QueueCurrentAndNextPlayer()
        'Enable Groupbox1
        'Disable btnEndRoundScore
        GroupBox1.Enabled = True
        btnEndRoundScore.Enabled = False
        'Declare Endround Truen and BidRound False
        BidRound = False
        EndRound = True
        'Declare Round Ended and Start EndRound
        ListBox1.Items.Add("+++ End Round " & row & " +++")
        ListBox1.Items.Add(".....................")
        ListBox1.Items.Add("Cate a facut " & CurrentPlayer & " ?")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
        'Enable only the buttons for the curent round
        ifRoundEnableButton()
    End Sub

    'btnUpdateScore
    Private Sub btnUpdScore_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdScore.Click
        'Enable btnStartNextRound
        'Disable GroupBox1, btnEndRoundScore, btn UpdateScore
        btnStartNextRound.Enabled = True
        GroupBox1.Enabled = False
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        'Update Scores in DGV
        dgv1.Rows(row).Cells(1).Value = ScorP1()
        dgv1.Rows(row).Cells(4).Value = ScorP2()
        dgv1.Rows(row).Cells(7).Value = ScorP3()
        dgv1.Rows(row).Cells(10).Value = ScorP4()
        dgv1.Rows(row).Cells(13).Value = ScorP5()
        dgv1.Rows(row).Cells(16).Value = ScorP6()
        'System Window Message to announce Scores Round
        ListBox1.Items.Add("+++ Scorul Runda " & row & " +++")
        ListBox1.Items.Add(".....................")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
        'Check if TotalEndBid matches cRound and if different display message
        If dgv1.Rows(row).Cells(20).Value = cRound Then
            'Loop Current and Next Player
            c.Dequeue()
            nextP.Dequeue()
            d.Dequeue()
        ElseIf dgv1.Rows(row).Cells(20).Value > cRound Then
            MsgBox("Ai adaugat prea multe! Rescrie Runda!")
            dgv1.Rows.Remove(dgv1.Rows(row))
            row -= 1
            cRoundIndex -= 1
        ElseIf dgv1.Rows(row).Cells(20).Value < cRound Then
            MsgBox("Ai adaugat prea putine! Rescrie Runda!")
            dgv1.Rows.Remove(dgv1.Rows(row))
            row -= 1
            cRoundIndex -= 1
        End If

        'Increase row Value to go to Next DGV row
        row += 1

        WinCondition()
    End Sub



    'Check if any Radio Buttons Checked and Display the right message
    Private Sub CheckGameOptions()
        Dim PlayersOK As Boolean = False
        Dim TableOK As Boolean = False
        Dim PunctajOK As Boolean = False

        If Radio4Players.Checked = False And Radio5Players.Checked = False And Radio6Players.Checked = False Then
            MsgBox("Nici macar nu ai selectat cati jucatori. Bouole.")
        End If
        If Radio111x111.Checked = False And Radio888x888.Checked = False Then
            MsgBox("Nu ai selectat tipul de tabel.")
        End If
        If radioNormal.Checked = False And RadioProgresiv.Checked = False Then
            MsgBox("Nu ai selectat tipul de punctaj.")
        End If

        If Radio4Players.Checked = True Or Radio5Players.Checked = True Or Radio6Players.Checked = True Then
            PlayersOK = True
        End If
        If Radio111x111.Checked = True Or Radio888x888.Checked = True Then
            TableOK = True
        End If
        If radioNormal.Checked = True Or RadioProgresiv.Checked = True Then
            PunctajOK = True
        End If

        'Add Listbox Messages 
        If Radio4Players.Checked = True Then
            ListBox1.Items.Add("Jucatori: 4")
        End If
        If Radio5Players.Checked = True Then
            ListBox1.Items.Add("Jucatori: 5")
        End If
        If Radio6Players.Checked = True Then
            ListBox1.Items.Add("Jucatori: 6")
        End If
        If Radio111x111.Checked = True Then
            ListBox1.Items.Add("Tabel tip: 111...888...111")
            Table1x8x1 = True
        End If
        If Radio888x888.Checked = True Then
            ListBox1.Items.Add("Tabel tip: 888...111...888")
            Table8x1x8 = True
        End If
        If CheckBoxDubluPunctaj.Checked = True Then
            ListBox1.Items.Add("Dublu la 2/2, 3/3, 4/4, etc..")
        End If
        If CheckBoxPremiere.Checked = True Then
            ListBox1.Items.Add("Cu premiere la" & TotalPlayers + 1)
        End If
        If radioNormal.Checked = True Then
            ListBox1.Items.Add("Punctaj: Normal")
            ListBox1.Items.Add(".....................")
        End If
        If RadioProgresiv.Checked = True Then
            ListBox1.Items.Add("Punctaj: Progresiv")
            ListBox1.Items.Add(".....................")
        End If


        If PlayersOK = True And TableOK = True And PunctajOK = True Then
            GameON = True
        End If

    End Sub
    'btnOk to Select Type of Score and nr of players and table type
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        CheckGameOptions()
        'The Big IF
        If GameON = True Then
            lblGameSetup.Visible = False

            'DubluPunctaj
            If CheckBoxDubluPunctaj.Checked = True Then
                DubluPunctaj = True
            End If
            'Cu Premiere
            If CheckBoxPremiere.Checked = True Then
                CuPremiere = True
            End If

            'If Statements for Normal or Progresive
            If radioNormal.Checked Then
                btnStartNextRound.Enabled = True
                dgv1.Visible = True
                GroupBox2.Visible = False
                PunctajNormal = True
                lblPunctajTip.Text = "Punctaj tip: Normal"
            ElseIf RadioProgresiv.Checked Then
                btnStartNextRound.Enabled = True
                dgv1.Visible = True
                GroupBox2.Visible = False
                PunctajProgresiv = True
                lblPunctajTip.Text = "Punctaj tip: Progresiv"
            Else
                btnOk.Enabled = False
            End If
            'If Statements for 4 Players
            If Radio4Players.Checked Then
                Panel5.Visible = True
                GroupBox1.Visible = True
                TotalPlayers = 4
                ListBox1.Items.Add("Adauga Numele Jucatorilor!")
                ListBox1.Items.Add(".....................")
                Player5.Visible = False
                Player6.Visible = False
                BidP5.Visible = False
                EndP5.Visible = False
                BidP6.Visible = False
                EndP6.Visible = False

                Player1Name = InputBox("Nume Player1: ", "title")
                dgv1.Columns(1).HeaderText = Player1Name
                ListBox1.Items.Add("Nume Player1: " & Player1Name)
                Player2Name = InputBox("Nume Player2: ", "title")
                dgv1.Columns(4).HeaderText = Player2Name
                ListBox1.Items.Add("Nume Player2: " & Player2Name)
                Player3Name = InputBox("Nume Player3: ", "title")
                dgv1.Columns(7).HeaderText = Player3Name
                ListBox1.Items.Add("Nume Player3: " & Player3Name)
                Player4Name = InputBox("Nume Player4: ", "title")
                dgv1.Columns(10).HeaderText = Player4Name
                ListBox1.Items.Add("Nume Player4: " & Player4Name)
                ListBox1.Items.Add(".....................")
            End If
            'If Statements for 5 Players
            If Radio5Players.Checked Then
                Panel5.Visible = True
                GroupBox1.Visible = True
                TotalPlayers = 5
                ListBox1.Items.Add("Adauga Numele Jucatorilor!")
                Player6.Visible = False
                BidP6.Visible = False
                EndP6.Visible = False
                Player1Name = InputBox("Nume Player1:  ", "title")
                dgv1.Columns(1).HeaderText = Player1Name
                ListBox1.Items.Add("Nume Player1: " & Player1Name)
                Player2Name = InputBox("Nume Player2:  ", "title")
                dgv1.Columns(4).HeaderText = Player2Name
                ListBox1.Items.Add("Nume Player2: " & Player2Name)
                Player3Name = InputBox("Nume Player3:  ", "title")
                dgv1.Columns(7).HeaderText = Player3Name
                ListBox1.Items.Add("Nume Player3: " & Player3Name)
                Player4Name = InputBox("Nume Player4:  ", "title")
                dgv1.Columns(10).HeaderText = Player4Name
                ListBox1.Items.Add("Nume Player4: " & Player4Name)
                Player5Name = InputBox("Nume Player5:  ", "title")
                dgv1.Columns(13).HeaderText = Player5Name
                ListBox1.Items.Add("Nume Player5: " & Player5Name)
                ListBox1.Items.Add(".....................")
            End If
            'If Statements for 6 Players
            If Radio6Players.Checked Then
                Panel5.Visible = True
                GroupBox1.Visible = True
                TotalPlayers = 6
                ListBox1.Items.Add("Adauga Numele Jucatorilor!")
                Player1Name = InputBox("Nume Player1: ", "title")
                dgv1.Columns(1).HeaderText = Player1Name
                ListBox1.Items.Add("Nume Player1: " & Player1Name)
                Player2Name = InputBox("Nume Player2: ", "title")
                dgv1.Columns(4).HeaderText = Player2Name
                ListBox1.Items.Add("Nume Player2: " & Player2Name)
                Player3Name = InputBox("Nume Player3: ", "title")
                dgv1.Columns(7).HeaderText = Player3Name
                ListBox1.Items.Add("Nume Player3: " & Player3Name)
                Player4Name = InputBox("Nume Player4: ", "title")
                dgv1.Columns(10).HeaderText = Player4Name
                ListBox1.Items.Add("Nume Player4: " & Player4Name)
                Player5Name = InputBox("Nume Player5: ", "title")
                dgv1.Columns(13).HeaderText = Player5Name
                ListBox1.Items.Add("Nume Player5: " & Player5Name)
                Player6Name = InputBox("Nume Player6: ", "title")
                dgv1.Columns(16).HeaderText = Player6Name
                ListBox1.Items.Add("Nume Player6: " & Player6Name)
                ListBox1.Items.Add(".....................")
            End If
        End If
    End Sub





    'End Game WinCondition
    Private Sub WinCondition()
        If TotalPlayers = 4 Then
            If cRoundIndex = 0 And row > 2 Then

                MsgBox("U win!")
                btnStartNextRound.Enabled = False



            End If

        End If
    End Sub

    'Export to Excel
    Private Sub ExportToExcel()
        Dim headers = (From header As DataGridViewColumn In dgv1.Columns.Cast(Of DataGridViewColumn)() _
        Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In dgv1.Rows.Cast(Of DataGridViewRow)() _
                   Where Not row.IsNewRow _
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Using sw As New IO.StreamWriter("csv.txt")
            sw.WriteLine(String.Join(",", headers))
            For Each r In rows
                sw.WriteLine(String.Join(",", r))
            Next
        End Using
        Process.Start("csv.txt")
    End Sub





    'Handes the Text in the Examples TextBoxes
    'Private Sub TextPunctajNormal()
    '    txtPunctajNormal.Text = "Exemplu: " & Environment.NewLine & "Facut 1 = 6p (5+1)" & Environment.NewLine _
    '        & "Facut 2 = 7p (5+2)" & Environment.NewLine & "Facut 3 = 8p (5+3)" & Environment.NewLine & Environment.NewLine _
    '        & "Gresit 1 = -1p" & Environment.NewLine & "Gresit 2 = -2p" & Environment.NewLine & "Gresit 3 = -3p"
    'End Sub
    'Private Sub TextPunctajProgresiv()
    '    txtPunctajProgresiv.Text = "Exemplu: " & Environment.NewLine & "Facut 1 = 6p (5+1)" & Environment.NewLine _
    '        & "Facut 2 = 8p (5+1+2)" & Environment.NewLine & "Facut 3 = 11p (5+1+2+3)" & Environment.NewLine & Environment.NewLine _
    '        & "Gresit 1 = -1p" & Environment.NewLine & "Gresit 2 = -3p (-1-2)" & Environment.NewLine & "Gresit 3 = -6p (-1-2-3)" _
    '        & Environment.NewLine & Environment.NewLine & "(work in progress...) "
    'End Sub






End Class