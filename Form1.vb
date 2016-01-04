Public Class Form1

#Region "Variables"
    Dim fileDateTime As String = DateTime.Now.ToString("yyyy-MM-dd") & "_" & DateTime.Now.ToString("HH-mm")

    Dim TotalPlayers As Integer
    Dim Player1Name As String = "Player1"
    Dim Player2Name As String = "Player2"
    Dim Player3Name As String = "Player3"
    Dim Player4Name As String = "Player4"
    Dim Player5Name As String = "Player5"
    Dim Player6Name As String = "Player6"

    Dim Player1NameTurn As Boolean = True
    Dim Player2NameTurn As Boolean = False
    Dim Player3NameTurn As Boolean = False
    Dim Player4NameTurn As Boolean = False
    Dim Player5NameTurn As Boolean = False
    Dim Player6NameTurn As Boolean = False

    Dim Player1Color As Color = Nothing
    Dim Player2Color As Color = Nothing
    Dim Player3Color As Color = Nothing
    Dim Player4Color As Color = Nothing
    Dim Player5Color As Color = Nothing
    Dim Player6Color As Color = Nothing

    Dim culoare As Color = Nothing

    Dim CurrentPlayer As String = "Waiting info Current Player ..."
    Dim NextPlayer As String = "Waiting info Next Player ..."
    Dim CurrentDealer As String = "Waiting info Dealer ..."

    Dim PreviousPlayer As String = "Waiting info PrevPlayer ..."
    Dim CurrentPlayerStack As New Stack
    Dim NextPlayerStack As New Stack
    Dim DealerStack As New Stack

    Dim row As Integer = 0
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
    Dim DealerQueue As New Queue()
    Dim CurrentPlayerQueue As New Queue()
    Dim NextPlayerQueue As New Queue()

    Dim Table1x8x1 As Boolean = False
    Dim Table8x1x8 As Boolean = False

    Dim strikeout As New Font("Berlin Sans FB", 14, FontStyle.Strikeout, GraphicsUnit.Point, Nothing)

    'Holds cRound Values
    Dim cRoundValuesx4x1() As Integer = {1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1}
    Dim cRoundValuesx5x1() As Integer = {1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1}
    Dim cRoundValuesx6x1() As Integer = {1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1}
    Dim cRoundValuesx4x8() As Integer = {8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8}
    Dim cRoundValuesx5x8() As Integer = {8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8}
    Dim cRoundValuesx6x8() As Integer = {8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8}
    Dim cRoundIndex As Integer
    Dim cRound As Integer = 1
#End Region

    'FormLoad
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Enable Changing Columns Header Color and Enable COLOR BUTTONS
        PanelCharts.Visible = False
        dgv1.EnableHeadersVisualStyles = False
        EnableColorbuttons()
        ResetPlayerNames()
        'Center DGV HeaderText
        For centerHeaderText As Integer = 0 To 18
            dgv1.Columns(centerHeaderText).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        Next centerHeaderText
        'Make all labels and New Game invisible
        PanelLables.Visible = False
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        btnStartNextRound.Enabled = False
        GroupBox1.Visible = False
        GroupBox1.Enabled = False
        GroupBox2.Visible = True
        lblGameSetup.Visible = True
        Panel5.Visible = False
        dgv1.Visible = False
        btnNewGame.Visible = False
        GroupBoxNameColor.Visible = False
        btnStergeRunda.Visible = False
        btnStergeRunda.Enabled = False
        btnInapoi.Visible = False
        TimerToolStripMenuItem.Enabled = False
        ArhivaToolStripMenuItem.Checked = True
        'adding 1-st Score ROW
        dgv1.Rows.Add(0, "invisible")
        dgv1.Rows(0).Visible = False
        dgv1.Rows(0).Cells(1).Value = 0
        dgv1.Rows(0).Cells(4).Value = 0
        dgv1.Rows(0).Cells(7).Value = 0
        dgv1.Rows(0).Cells(10).Value = 0
        dgv1.Rows(0).Cells(13).Value = 0
        dgv1.Rows(0).Cells(16).Value = 0
        dgv1.Rows(0).Cells(21).Value = 0
        dgv1.Rows(0).Cells(22).Value = 0
        dgv1.Rows(0).Cells(23).Value = 0
        dgv1.Rows(0).Cells(24).Value = 0
        dgv1.Rows(0).Cells(25).Value = 0
        dgv1.Rows(0).Cells(26).Value = 0
        'Welcome Messages In System Window
        Listbox1.Items.Add("Game Setup")
        Listbox1.Items.Add(".....................")
        Listbox1.TopIndex = Listbox1.Items.Count - 1
    End Sub

#Region "Increment Rounds"
    'Increments cRoundValuesx4x1 , cRoundValuesx4x8, cRoundValuesx5x1, cRoundValuesx5x8, cRoundValuesx6x1, cRoundValuesx6x8
    Public Sub IncrementcRoundIndexX4x1(ByVal x As Integer)
        cRound = cRoundValuesx4x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx4x1.Length Then cRoundIndex = 0 'End Game
    End Sub
    Public Sub IncrementcRoundIndexX4x8(ByVal x As Integer)
        cRound = cRoundValuesx4x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx4x8.Length Then cRoundIndex = 0 'End Game
    End Sub
    Public Sub IncrementcRoundIndexX5x1(ByVal x As Integer)
        cRound = cRoundValuesx5x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx5x1.Length Then cRoundIndex = 0 'End Game
    End Sub
    Public Sub IncrementcRoundIndexX5x8(ByVal x As Integer)
        cRound = cRoundValuesx5x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx5x8.Length Then cRoundIndex = 0 'End Game
    End Sub
    Public Sub IncrementcRoundIndexX6x1(ByVal x As Integer)
        cRound = cRoundValuesx6x1(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx6x1.Length Then cRoundIndex = 0 'End Game
    End Sub
    Public Sub IncrementcRoundIndexX6x8(ByVal x As Integer)
        cRound = cRoundValuesx6x8(cRoundIndex) 'Only this increments
        cRoundIndex += 1
        If cRoundIndex = cRoundValuesx6x8.Length Then cRoundIndex = 0 'End Game
    End Sub
#End Region

#Region "Enqueue Player Dealer turns"
    'Queue LoadCurrentAndNextPlayer Player 
    Private Sub LoadCurrentAndNextPlayer()
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
        CurrentPlayerQueue.Enqueue(Player1Name)
        CurrentPlayerQueue.Enqueue(Player2Name)
        CurrentPlayerQueue.Enqueue(Player3Name)
        CurrentPlayerQueue.Enqueue(Player4Name)
        CurrentPlayer = CurrentPlayerQueue.Peek()
    End Sub
    Private Sub CurrentPlayerx5()
        CurrentPlayerQueue.Enqueue(Player1Name)
        CurrentPlayerQueue.Enqueue(Player2Name)
        CurrentPlayerQueue.Enqueue(Player3Name)
        CurrentPlayerQueue.Enqueue(Player4Name)
        CurrentPlayerQueue.Enqueue(Player5Name)
        CurrentPlayer = CurrentPlayerQueue.Peek()
    End Sub
    Private Sub CurrentPlayerx6()
        CurrentPlayerQueue.Enqueue(Player1Name)
        CurrentPlayerQueue.Enqueue(Player2Name)
        CurrentPlayerQueue.Enqueue(Player3Name)
        CurrentPlayerQueue.Enqueue(Player4Name)
        CurrentPlayerQueue.Enqueue(Player5Name)
        CurrentPlayerQueue.Enqueue(Player6Name)
        CurrentPlayer = CurrentPlayerQueue.Peek()
    End Sub
    'Next Player x4   
    Private Sub NextPlayerx4()
        NextPlayerQueue.Enqueue(Player2Name)
        NextPlayerQueue.Enqueue(Player3Name)
        NextPlayerQueue.Enqueue(Player4Name)
        NextPlayerQueue.Enqueue(Player1Name)
        NextPlayer = NextPlayerQueue.Peek()
    End Sub
    Private Sub NextPlayerx5()
        NextPlayerQueue.Enqueue(Player2Name)
        NextPlayerQueue.Enqueue(Player3Name)
        NextPlayerQueue.Enqueue(Player4Name)
        NextPlayerQueue.Enqueue(Player5Name)
        NextPlayerQueue.Enqueue(Player1Name)
        NextPlayer = NextPlayerQueue.Peek()
    End Sub
    Private Sub NextPlayerx6()
        NextPlayerQueue.Enqueue(Player2Name)
        NextPlayerQueue.Enqueue(Player3Name)
        NextPlayerQueue.Enqueue(Player4Name)
        NextPlayerQueue.Enqueue(Player5Name)
        NextPlayerQueue.Enqueue(Player6Name)
        NextPlayerQueue.Enqueue(Player1Name)
        NextPlayer = NextPlayerQueue.Peek()
    End Sub
    'Dealer Turn Queue 
    Private Sub DealerTurnx4()
        DealerQueue.Enqueue(Player4Name)
        DealerQueue.Enqueue(Player1Name)
        DealerQueue.Enqueue(Player2Name)
        DealerQueue.Enqueue(Player3Name)
        CurrentDealer = DealerQueue.Peek()
    End Sub
    Private Sub DealerTurnx5()
        DealerQueue.Enqueue(Player5Name)
        DealerQueue.Enqueue(Player1Name)
        DealerQueue.Enqueue(Player2Name)
        DealerQueue.Enqueue(Player3Name)
        DealerQueue.Enqueue(Player4Name)
        CurrentDealer = DealerQueue.Peek()
    End Sub
    Private Sub DealerTurnx6()
        DealerQueue.Enqueue(Player6Name)
        DealerQueue.Enqueue(Player1Name)
        DealerQueue.Enqueue(Player2Name)
        DealerQueue.Enqueue(Player3Name)
        DealerQueue.Enqueue(Player4Name)
        DealerQueue.Enqueue(Player5Name)
        CurrentDealer = DealerQueue.Peek()

    End Sub
#End Region

#Region "Check TotalPlayers, Round-Disable-Btns, TotalBid, RadioButtons, DisableUsedColors"
    'Check how manny total players and Check if all Bided then disable bid buttons and stop/reset Timer2
    Private Sub IfAllBidDisableBids()
        If TotalPlayers = 4 Then
            If BidRound = True And Player1HasBided() And Player2HasBided() And Player3HasBided() And Player4HasBided() = True Then
                DisableAllBids()
                Timer2.Enabled = False
                lblPlayerSeconds.Text = 0
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
                Timer2.Enabled = False
                lblPlayerSeconds.Text = 0
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
                Timer2.Enabled = False
                lblPlayerSeconds.Text = 0
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
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 2 Obigate Dealer
            If cRound = 2 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If

                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF ROund = 3 Obigate Dealer
            If cRound = 3 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 4 Obigate Dealer
            If cRound = 4 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn4.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 4!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 5 Obigate Dealer
            If cRound = 5 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn5.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 5!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn4.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 4!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 6 Obigate Dealer
            If cRound = 6 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn6.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 6!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn5.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 5!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn4.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 4!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 7 Obigate Dealer
            If cRound = 7 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn7.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 7!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn6.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 6!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn5.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 5!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn4.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 4!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 7 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
            '''''' IF Round = 8 Obigate Dealer
            If cRound = 8 Then
                If NextPlayer = CurrentDealer And TotalBids = 0 Then
                    btn8.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 8!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 1 Then
                    btn7.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 7!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 2 Then
                    btn6.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 6!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 3 Then
                    btn5.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 5!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 4 Then
                    btn4.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 4!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 5 Then
                    btn3.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 3!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 6 Then
                    btn2.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 2!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 7 Then
                    btn1.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 1!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
                If NextPlayer = CurrentDealer And TotalBids = 8 Then
                    btn0.Enabled = False
                    Listbox1.Items.Add(CurrentDealer & " fara 0!")
                    Listbox1.TopIndex = Listbox1.Items.Count - 1
                End If
            End If
        End If

    End Sub

    'Check TotalBid for CurrentDealer
    Public Sub CheckTotalBid()
        Dim P1Bid = dgv1.Rows(row).Cells(2).Value
        Dim P2Bid = dgv1.Rows(row).Cells(5).Value
        Dim P3Bid = dgv1.Rows(row).Cells(8).Value
        Dim P4Bid = dgv1.Rows(row).Cells(11).Value
        Dim P5Bid = dgv1.Rows(row).Cells(14).Value
        Dim P6Bid = dgv1.Rows(row).Cells(17).Value
        Dim P1End = dgv1.Rows(row).Cells(3).Value
        Dim P2End = dgv1.Rows(row).Cells(6).Value
        Dim P3End = dgv1.Rows(row).Cells(9).Value
        Dim P4End = dgv1.Rows(row).Cells(12).Value
        Dim P5End = dgv1.Rows(row).Cells(15).Value
        Dim P6End = dgv1.Rows(row).Cells(18).Value

        'Sets TotalBids and TotalEnds and DGV COLORS for that
        If TotalPlayers = 4 And BidRound = True Then
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Blue
        End If
        If TotalPlayers = 5 And BidRound = True Then
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid + P5Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Blue
        End If
        If TotalPlayers = 6 And BidRound = True Then
            TotalBids = P1Bid + P2Bid + P3Bid + P4Bid + P5Bid + P6Bid
            dgv1.Rows(row).Cells(19).Value = TotalBids
            dgv1.Rows(row).Cells(19).Style.ForeColor = Color.Blue
        End If
        If TotalPlayers = 4 And EndRound = True Then
            TotalEnds = P1End + P2End + P3End + P4End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Red
        End If
        If TotalPlayers = 5 And EndRound = True Then
            TotalEnds = P1End + P2End + P3End + P4End + P5End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Red
        End If
        If TotalPlayers = 6 And EndRound = True Then
            TotalEnds = P1End + P2End + P3End + P4End + P5End + P6End
            dgv1.Rows(row).Cells(20).Value = TotalEnds
            dgv1.Rows(row).Cells(20).Style.ForeColor = Color.Red
        End If

        'When EndRound is TRUE disables buttons so u don't make mistake Ending
        If EndRound Then
            If cRound = 1 Then
                If TotalEnds = 1 Then
                    btn1.Enabled = False
                End If
            End If

            If cRound = 2 Then
                If TotalEnds = 1 Then
                    btn2.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn1.Enabled = False
                    btn2.Enabled = False
                End If
            End If

            If cRound = 3 Then
                If TotalEnds = 1 Then
                    btn3.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn2.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn1.Enabled = False
                    btn2.Enabled = False
                    btn3.Enabled = False
                End If
            End If

            If cRound = 4 Then
                If TotalEnds = 1 Then
                    btn4.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn4.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                ElseIf TotalEnds = 4 Then
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                    btn1.Enabled = False
                End If
            End If

            If cRound = 5 Then
                If TotalEnds = 1 Then
                    btn5.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn5.Enabled = False
                    btn4.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 4 Then
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                ElseIf TotalEnds = 5 Then
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                    btn1.Enabled = False
                End If
            End If

            If cRound = 6 Then
                If TotalEnds = 1 Then
                    btn6.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn6.Enabled = False
                    btn5.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                ElseIf TotalEnds = 4 Then
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 5 Then
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                ElseIf TotalEnds = 6 Then
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                    btn1.Enabled = False
                End If
            End If
            If cRound = 7 Then
                If TotalEnds = 1 Then
                    btn7.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                ElseIf TotalEnds = 4 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                ElseIf TotalEnds = 5 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 6 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                ElseIf TotalEnds = 7 Then
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                    btn1.Enabled = False
                End If
            End If

            If cRound = 8 Then
                If TotalEnds = 1 Then
                    btn8.Enabled = False
                ElseIf TotalEnds = 2 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                ElseIf TotalEnds = 3 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                ElseIf TotalEnds = 4 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                ElseIf TotalEnds = 5 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                ElseIf TotalEnds = 6 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                ElseIf TotalEnds = 7 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                ElseIf TotalEnds = 8 Then
                    btn8.Enabled = False
                    btn7.Enabled = False
                    btn6.Enabled = False
                    btn5.Enabled = False
                    btn4.Enabled = False
                    btn3.Enabled = False
                    btn2.Enabled = False
                    btn1.Enabled = False
                End If
            End If
        End If

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
            Listbox1.Items.Add("Jucatori: 4")
        End If
        If Radio5Players.Checked = True Then
            Listbox1.Items.Add("Jucatori: 5")
        End If
        If Radio6Players.Checked = True Then
            Listbox1.Items.Add("Jucatori: 6")
        End If
        If Radio111x111.Checked = True Then
            Listbox1.Items.Add("Tabel tip: 111...888...111")
            Table1x8x1 = True
        End If
        If Radio888x888.Checked = True Then
            Listbox1.Items.Add("Tabel tip: 888...111...888")
            Table8x1x8 = True
        End If
        If CheckBoxDubluPunctaj.Checked = True Then
            Listbox1.Items.Add("Dublu la 2/2, 3/3, 4/4, etc..")
        End If
        If CheckBoxPremiere.Checked = True Then
            Listbox1.Items.Add("Cu premiere la" & TotalPlayers + 1)
        End If
        If radioNormal.Checked = True Then
            Listbox1.Items.Add("Punctaj: Normal")
            Listbox1.Items.Add(".....................")
        End If
        If RadioProgresiv.Checked = True Then
            Listbox1.Items.Add("Punctaj: Progresiv")
            Listbox1.Items.Add(".....................")
        End If


        If PlayersOK = True And TableOK = True And PunctajOK = True Then
            GameON = True
        End If

    End Sub

    'Check and Disable Used Colors
    Private Sub DisableColors()
        If culoare = Color.MediumSpringGreen Then 'disable Colors
            btnGreen.Enabled = False
            btnGreen.BackColor = Color.Gray
            culoare = Nothing
        ElseIf culoare = Color.Crimson Then
            btnCrimson.Enabled = False
            btnCrimson.BackColor = Color.Gray
            culoare = Nothing
        ElseIf culoare = Color.Gold Then
            btnGold.Enabled = False
            btnGold.BackColor = Color.Gray
            culoare = Nothing
        ElseIf culoare = Color.DodgerBlue Then
            btnBlue.Enabled = False
            btnBlue.BackColor = Color.Gray
            culoare = Nothing
        ElseIf culoare = Color.Orange Then
            btnOrange.Enabled = False
            btnOrange.BackColor = Color.Gray
            culoare = Nothing
        ElseIf culoare = Color.HotPink Then
            btnPink.Enabled = False
            btnPink.BackColor = Color.Gray
            culoare = Nothing
        End If
    End Sub
#End Region

#Region "Short code zone"
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
    'Disable DGV Selection
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.SelectionChanged
        If dgv1.SelectedCells.Count > 0 Then
            dgv1.ClearSelection()
        End If
    End Sub
#End Region

#Region "Highlight Players, Reset Player Names, NewNamesAndColors, Listbox Messages"
    'Add Listbox Messages
    Private Sub ListboxMsg()
        If BidRound = True And CurrentPlayer <> CurrentDealer Then
            Listbox1.Items.Add("Liciteaza " & NextPlayer)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
        End If
        If EndRound = True And CurrentPlayer <> CurrentDealer Then
            Listbox1.Items.Add("Cate a facut " & NextPlayer & " ?")
            Listbox1.TopIndex = Listbox1.Items.Count - 1
        End If
        lblCurentPlayerQueue.Text = "CurPlQue.count = " & CurrentPlayerQueue.Count
        lblNextPlayerQueue.Text = "NextPlQue.count = " & NextPlayerQueue.Count
        lblDealerQueue.Text = "DealerQue.count = " & DealerQueue.Count
        lblPreviousPlayerCount.Text = "PrevPlayer.count = " & CurrentPlayerStack.Count
        lblPlayer.Text = "CurrentPlayer: " & CurrentPlayer
        lblNextPlayer.Text = "Next Player: " & NextPlayer
        lblDealer.Text = ("Dealer: " & CurrentDealer)
        lblcround.Text = ("cRound: " & cRound)

    End Sub
    'Highlight Curent Player
    Private Sub HighlightCurrentPlayer()
        If CurrentPlayer = Player1Name Then
            dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Gray
            dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf CurrentPlayer = Player2Name Then
            dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Gray
            dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf CurrentPlayer = Player3Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf CurrentPlayer = Player4Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf CurrentPlayer = Player5Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf CurrentPlayer = Player6Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Gray
        End If
    End Sub
    'Highlight Next Player
    Private Sub HighlightNextPlayer()
        If NextPlayer = Player1Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf NextPlayer = Player2Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf NextPlayer = Player3Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf NextPlayer = Player4Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf NextPlayer = Player5Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Gray
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        ElseIf NextPlayer = Player6Name Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Gray
        End If
        'Don't Highlight anything after dealer
        If CurrentPlayer = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.BackColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.BackColor = Color.Empty
        End If
    End Sub
    'Highlight Dealer
    Private Sub HighlightDealer()
        If Player1Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Red
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        ElseIf Player2Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Red
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        ElseIf Player3Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Red
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        ElseIf Player4Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Red
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        ElseIf Player5Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Red
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        ElseIf Player6Name = CurrentDealer Then
            Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
            Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Red
        End If
    End Sub
    'AddMybid and Mouseover Message "a zis"
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
    'AddEndBid and Mouseover Message "a facut"
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
    'Reset Player Names
    Private Sub ResetPlayerNames()
        Player1Name = "Player1"
        dgv1.Columns(1).HeaderText = Player1Name
        Player2Name = "Player2"
        dgv1.Columns(4).HeaderText = Player2Name
        Player3Name = "Player3"
        dgv1.Columns(7).HeaderText = Player3Name
        Player4Name = "Player4"
        dgv1.Columns(10).HeaderText = Player4Name
        Player5Name = "Player5"
        dgv1.Columns(13).HeaderText = Player5Name
        Player6Name = "Player6"
        dgv1.Columns(16).HeaderText = Player6Name
    End Sub
    'NewNamesAndColors
    Private Sub NewNamesAndColors()
        GroupBoxNameColor.Visible = True
        lblEnterNames.Text = "Player1 Alege Numele si Culoarea"
        'If Statements for 4 Players
        If Radio4Players.Checked Then
            Panel5.Visible = True
            GroupBox1.Visible = True
            TotalPlayers = 4
            Listbox1.Items.Add("Adauga Numele Jucatorilor!")
            Listbox1.Items.Add(".....................")
            Player5.Visible = False
            Player6.Visible = False
            BidP5.Visible = False
            EndP5.Visible = False
            BidP6.Visible = False
            EndP6.Visible = False
        ElseIf Radio5Players.Checked Then
            Panel5.Visible = True
            GroupBox1.Visible = True
            TotalPlayers = 5
            Listbox1.Items.Add("Adauga Numele Jucatorilor!")
            Player6.Visible = False
            BidP6.Visible = False
            EndP6.Visible = False
        ElseIf Radio6Players.Checked Then
            Panel5.Visible = True
            GroupBox1.Visible = True
            TotalPlayers = 6
            Listbox1.Items.Add("Adauga Numele Jucatorilor!")
            Listbox1.Items.Add(".....................")
        End If
    End Sub
#End Region

#Region "Bid Buttons"
    'btn0
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 0
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        End If
        If EndRound = True Then
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 0
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        NextPlayerStack.Push(NextPlayerQueue.Dequeue())
        CurrentPlayerStack.Push(CurrentPlayerQueue.Dequeue())
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn1
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 1
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        End If
        If EndRound = True Then
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 1
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        NextPlayerStack.Push(NextPlayerQueue.Dequeue())
        CurrentPlayerStack.Push(CurrentPlayerQueue.Dequeue())
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()
    End Sub
    'btn2
    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 2
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 2
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn3
    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 3
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 3
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn4
    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 4
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 4
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn5
    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 5
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 5
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn6
    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 6
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 6
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn7
    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 7
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 7
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
        HighlightNextPlayer()

    End Sub
    'btn8
    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        'Loop Current Player
        LoadCurrentAndNextPlayer()
        'check if it's bidRound or endRound and add MyBid or EndBid
        If BidRound = True Then
            myBid = 8
            Listbox1.Items.Add(CurrentPlayer & " a licitat " & myBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            AddMyBid()
        Else
            Listbox1.Items.Add(CurrentPlayer & " a facut " & endBid)
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            endBid = 8
            AddEndBid()
        End If
        'Ia timpul dintre doua biduri
        TimeCheck()
        'if everyone has bid then disable bid buttons
        IfAllBidDisableBids()
        'Loop Current and Next Player
        CurrentPlayerQueue.Dequeue()
        NextPlayerQueue.Dequeue()
        'Add Listbox Items depending if it's BidRound or EndRound
        ListboxMsg()
        'Check all Entered bids and update the TotalRoundBid
        CheckTotalBid() '+ mai nou verifica TotalEnd si da disable la butoane descrescator
        'Check Round and CurrentPlayer and Disable Button for Dealer FaraX
        DealerFaraX()
    End Sub
#End Region

#Region "Scoruri"
    'ScorP1
    Public Function ScorP1() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(2).Value 'Licitat value
            Dim E1 As Integer = dgv1.Rows(row).Cells(3).Value 'Cate a facut value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(1).Value 'Cate puncte avea jocul trecut
            Dim D1 As Integer = Math.Abs(L1 - E1) 'difference of bid must be always possitive
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5 'Total is Old Points + Bid + 5
                End If
            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(2).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(2).Style.Font = strikeout
                T1 = PL - D1
            End If

        Catch ex As Exception
        End Try
        Return T1

    End Function
    'ScorP2
    Public Function ScorP2() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(5).Value
            Dim E1 As Integer = dgv1.Rows(row).Cells(6).Value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(4).Value
            Dim D1 As Integer = Math.Abs(L1 - E1)
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5
                End If
                'Total is Old Points + Bid + 5

            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(5).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(5).Style.Font = strikeout
                T1 = PL - D1
            End If

        Catch ex As Exception
        End Try

        Return T1
    End Function
    'ScorP3
    Public Function ScorP3() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(8).Value
            Dim E1 As Integer = dgv1.Rows(row).Cells(9).Value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(7).Value
            Dim D1 As Integer = Math.Abs(L1 - E1)
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5
                End If
                'Total is Old Points + Bid + 5

            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(8).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(8).Style.Font = strikeout
                T1 = PL - D1
            End If

        Catch ex As Exception
        End Try

        Return T1
    End Function
    'ScorP4
    Public Function ScorP4() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(11).Value
            Dim E1 As Integer = dgv1.Rows(row).Cells(12).Value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(10).Value
            Dim D1 As Integer = Math.Abs(L1 - E1)
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5
                End If
                'Total is Old Points + Bid + 5

            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(11).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(11).Style.Font = strikeout
                T1 = PL - D1
            End If

        Catch ex As Exception
        End Try

        Return T1
    End Function
    'ScorP5
    Public Function ScorP5() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(14).Value
            Dim E1 As Integer = dgv1.Rows(row).Cells(15).Value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(13).Value
            Dim D1 As Integer = Math.Abs(L1 - E1)
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5
                End If
                'Total is Old Points + Bid + 5

            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(14).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(14).Style.Font = strikeout
                T1 = PL - D1
            End If
        Catch ex As Exception
        End Try

        Return T1
    End Function
    'ScorP6
    Public Function ScorP6() As Integer
        Dim T1 = Nothing
        Try
            Dim L1 As Integer = dgv1.Rows(row).Cells(17).Value
            Dim E1 As Integer = dgv1.Rows(row).Cells(18).Value
            Dim PL As Integer = dgv1.Rows(row - 1).Cells(16).Value
            Dim D1 As Integer = Math.Abs(L1 - E1)
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
                If PunctajProgresiv = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (Pro + 5) * 2
                ElseIf PunctajNormal = True And DubluPunctaj = True And L1 >= 2 And L1 = cRound Then
                    T1 = PL + (L1 + 5) * 2
                ElseIf PunctajProgresiv = True Then
                    T1 = PL + Pro + 5
                Else
                    T1 = PL + L1 + 5
                End If
                'Total is Old Points + Bid + 5

            ElseIf D1 <> 0 And PunctajProgresiv = True Then 'if difference of bid is not 0 then 
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(17).Style.Font = strikeout
                'subtract difference from score
                T1 = PL - D1Pro
            ElseIf D1 <> 0 Then
                'strikeout text of bid if mistake
                dgv1.Rows(row).Cells(17).Style.Font = strikeout
                T1 = PL - D1
            End If

        Catch ex As Exception
        End Try

        Return T1
    End Function
#End Region

#Region "Buttons Select Color, Enable Color for FormLoad"
    'Enable Color Buttons for FormLoad
    Private Sub EnableColorbuttons()
        btnGreen.Enabled = True
        btnGreen.BackColor = Color.MediumSpringGreen
        btnCrimson.Enabled = True
        btnCrimson.BackColor = Color.Crimson
        btnGold.Enabled = True
        btnGold.BackColor = Color.Gold
        btnBlue.Enabled = True
        btnBlue.BackColor = Color.DodgerBlue
        btnOrange.Enabled = True
        btnOrange.BackColor = Color.Orange
        btnPink.Enabled = True
        btnPink.BackColor = Color.HotPink
    End Sub
    Private Sub btnGreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGreen.Click
        btnGreen.Text = "X"
        btnCrimson.Text = ""
        btnGold.Text = ""
        btnBlue.Text = ""
        btnOrange.Text = ""
        btnPink.Text = ""
        culoare = Color.MediumSpringGreen
    End Sub
    Private Sub btnCrimson_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCrimson.Click
        btnGreen.Text = ""
        btnCrimson.Text = "X"
        btnGold.Text = ""
        btnBlue.Text = ""
        btnOrange.Text = ""
        btnPink.Text = ""
        culoare = Color.Crimson
    End Sub
    Private Sub btnGold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGold.Click
        btnGreen.Text = ""
        btnCrimson.Text = ""
        btnGold.Text = "X"
        btnBlue.Text = ""
        btnOrange.Text = ""
        btnPink.Text = ""
        culoare = Color.Gold
    End Sub
    Private Sub btnBlue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBlue.Click
        btnGreen.Text = ""
        btnCrimson.Text = ""
        btnGold.Text = ""
        btnBlue.Text = "X"
        btnOrange.Text = ""
        btnPink.Text = ""
        culoare = Color.DodgerBlue
    End Sub
    Private Sub btnOrange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOrange.Click
        btnGreen.Text = ""
        btnCrimson.Text = ""
        btnGold.Text = ""
        btnBlue.Text = ""
        btnOrange.Text = "X"
        btnPink.Text = ""
        culoare = Color.Orange
    End Sub
    Private Sub btnPink_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPink.Click
        btnGreen.Text = ""
        btnCrimson.Text = ""
        btnGold.Text = ""
        btnBlue.Text = ""
        btnOrange.Text = ""
        btnPink.Text = "X"
        culoare = Color.HotPink
    End Sub
#End Region

#Region "Buttons Ok, NameOk, NewGame, StergeRunda"

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
                lblCuPremiere.Text = "CU PREMIERE!"
            End If
            'If Statements for Normal or Progresive
            If radioNormal.Checked Then
                dgv1.Visible = True
                GroupBox2.Visible = False
                PunctajNormal = True
                lblPunctajTip.Text = "Punctaj tip: Normal"
            ElseIf RadioProgresiv.Checked Then
                dgv1.Visible = True
                GroupBox2.Visible = False
                PunctajProgresiv = True
                lblPunctajTip.Text = "Punctaj tip: Progresiv"
            Else
                btnOk.Enabled = False
            End If
            'Enter Player Names and Choose Colors
            NewNamesAndColors()
            ''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''' THIS IS ONLY FOR DEBUG
            'GroupBox1.Visible = True
            'Panel5.Visible = True
            'btnStartNextRound.Enabled = True
            'Player1Name = "P1"
            'Player1Name = "P2"
            'Player1Name = "P3"
            'Player1Name = "P4"
            ''''''''''''''''''''''''''''''''''''''

        End If
    End Sub

    'btnNameOk
    Private Sub btnNameOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNameOk.Click
        If txtNames.Text = "" Then
            MsgBox("N-ai scris nimic Boule.")
        Else
            If culoare = Nothing Then  'daca n-a ales culoare
                MsgBox("Nu ai ales culoarea.")
            ElseIf culoare <> Nothing Then 'daca a ales culoare

                btnGreen.Text = ""   'Delete All Marks From Color Buttons
                btnCrimson.Text = ""
                btnGold.Text = ""
                btnBlue.Text = ""
                btnOrange.Text = ""
                btnPink.Text = ""

                If TotalPlayers = 4 Then
                    If Player1NameTurn = True Then 'daca e randul Player1
                        Player1Color = culoare
                        lblEnterNames.Text = "Player2 Alege Numele si Culoarea"
                        Me.dgv1.Columns(1).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(2).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(3).DefaultCellStyle.BackColor = culoare
                        Player1Name = txtNames.Text
                        dgv1.Columns(1).HeaderText = Player1Name  'scrie numele in dgv header
                        Listbox1.Items.Add("Nume Player1: " & Player1Name) 'adauga mesaj in listbox
                        Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                        txtNames.Clear()         'sterge textbox
                        Player1NameTurn = False
                        Player2NameTurn = True
                        DisableColors() 'Check and Disable Used Colors

                    ElseIf Player2NameTurn = True Then 'daca e randul Player2
                        lblEnterNames.Text = "Player3 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Then
                            Player2Color = culoare
                            Me.dgv1.Columns(4).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(5).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(6).DefaultCellStyle.BackColor = culoare
                            Player2Name = txtNames.Text
                            dgv1.Columns(4).HeaderText = Player2Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player2: " & Player2Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player2NameTurn = False
                            Player3NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player3NameTurn = True Then 'daca e randul Player3
                        lblEnterNames.Text = "Player4 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Then
                            Player3Color = culoare
                            Me.dgv1.Columns(7).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(8).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(9).DefaultCellStyle.BackColor = culoare
                            Player3Name = txtNames.Text
                            dgv1.Columns(7).HeaderText = Player3Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player3: " & Player3Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player3NameTurn = False
                            Player4NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player4NameTurn = True Then 'daca e randul Player4
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Then
                            Player4Color = culoare
                            Me.dgv1.Columns(10).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(11).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(12).DefaultCellStyle.BackColor = culoare
                            Player4Name = txtNames.Text
                            dgv1.Columns(10).HeaderText = Player4Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player4: " & Player4Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player4NameTurn = False
                            Player1NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                            GroupBoxNameColor.Visible = False
                            btnStartNextRound.Enabled = True
                        End If
                    End If

                ElseIf TotalPlayers = 5 Then
                    lblEnterNames.Text = "Player2 Alege Numele si Culoarea"
                    If Player1NameTurn = True Then 'daca e randul Player1
                        Player1Color = culoare
                        Me.dgv1.Columns(1).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(2).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(3).DefaultCellStyle.BackColor = culoare
                        Player1Name = txtNames.Text
                        dgv1.Columns(1).HeaderText = Player1Name  'scrie numele in dgv header
                        Listbox1.Items.Add("Nume Player1: " & Player1Name) 'adauga mesaj in listbox
                        Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                        txtNames.Clear()         'sterge textbox
                        Player1NameTurn = False
                        Player2NameTurn = True
                        DisableColors() 'Check and Disable Used Colors

                    ElseIf Player2NameTurn = True Then 'daca e randul Player2
                        lblEnterNames.Text = "Player3 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Then
                            Player2Color = culoare
                            Me.dgv1.Columns(4).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(5).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(6).DefaultCellStyle.BackColor = culoare
                            Player2Name = txtNames.Text
                            dgv1.Columns(4).HeaderText = Player2Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player2: " & Player2Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player2NameTurn = False
                            Player3NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player3NameTurn = True Then 'daca e randul Player3
                        lblEnterNames.Text = "Player4 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Then
                            Player3Color = culoare
                            Me.dgv1.Columns(7).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(8).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(9).DefaultCellStyle.BackColor = culoare
                            Player3Name = txtNames.Text
                            dgv1.Columns(7).HeaderText = Player3Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player3: " & Player3Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player3NameTurn = False
                            Player4NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player4NameTurn = True Then 'daca e randul Player4
                        lblEnterNames.Text = "Player5 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Then
                            Player4Color = culoare
                            Me.dgv1.Columns(10).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(11).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(12).DefaultCellStyle.BackColor = culoare
                            Player4Name = txtNames.Text
                            dgv1.Columns(10).HeaderText = Player4Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player4: " & Player4Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player4NameTurn = False
                            Player5NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player5NameTurn = True Then 'daca e randul Player5
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Or txtNames.Text = Player4Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Or txtNames.Text <> Player4Name Then
                            Player5Color = culoare
                            Me.dgv1.Columns(13).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(14).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(15).DefaultCellStyle.BackColor = culoare
                            Player5Name = txtNames.Text
                            dgv1.Columns(13).HeaderText = Player5Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player5: " & Player5Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player5NameTurn = False
                            Player1NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                            GroupBoxNameColor.Visible = False
                            btnStartNextRound.Enabled = True
                        End If
                    End If

                ElseIf TotalPlayers = 6 Then
                    lblEnterNames.Text = "Player2 Alege Numele si Culoarea"
                    If Player1NameTurn = True Then 'daca e randul Player1
                        Player1Color = culoare
                        Me.dgv1.Columns(1).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(2).DefaultCellStyle.BackColor = culoare
                        Me.dgv1.Columns(3).DefaultCellStyle.BackColor = culoare
                        Player1Name = txtNames.Text
                        dgv1.Columns(1).HeaderText = Player1Name  'scrie numele in dgv header
                        Listbox1.Items.Add("Nume Player1: " & Player1Name) 'adauga mesaj in listbox
                        Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                        txtNames.Clear()         'sterge textbox
                        Player1NameTurn = False
                        Player2NameTurn = True
                        DisableColors() 'Check and Disable Used Colors

                    ElseIf Player2NameTurn = True Then 'daca e randul Player2
                        lblEnterNames.Text = "Player3 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Then
                            Player2Color = culoare
                            Me.dgv1.Columns(4).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(5).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(6).DefaultCellStyle.BackColor = culoare
                            Player2Name = txtNames.Text
                            dgv1.Columns(4).HeaderText = Player2Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player2: " & Player2Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player2NameTurn = False
                            Player3NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player3NameTurn = True Then 'daca e randul Player3
                        lblEnterNames.Text = "Player4 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Then
                            Player3Color = culoare
                            Me.dgv1.Columns(7).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(8).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(9).DefaultCellStyle.BackColor = culoare
                            Player3Name = txtNames.Text
                            dgv1.Columns(7).HeaderText = Player3Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player3: " & Player3Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player3NameTurn = False
                            Player4NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player4NameTurn = True Then 'daca e randul Player4
                        lblEnterNames.Text = "Player5 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Then
                            Player4Color = culoare
                            Me.dgv1.Columns(10).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(11).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(12).DefaultCellStyle.BackColor = culoare
                            Player4Name = txtNames.Text
                            dgv1.Columns(10).HeaderText = Player4Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player4: " & Player4Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player4NameTurn = False
                            Player5NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                        End If

                    ElseIf Player5NameTurn = True Then 'daca e randul Player5
                        lblEnterNames.Text = "Player6 Alege Numele si Culoarea"
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Or txtNames.Text = Player4Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Or txtNames.Text <> Player4Name Then
                            Player5Color = culoare
                            Me.dgv1.Columns(13).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(14).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(15).DefaultCellStyle.BackColor = culoare
                            Player5Name = txtNames.Text
                            dgv1.Columns(13).HeaderText = Player5Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player5: " & Player5Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player5NameTurn = False
                            Player6NameTurn = True
                            DisableColors() 'Check and Disable Used Colors

                        End If
                    ElseIf Player6NameTurn = True Then 'daca e randul Player6
                        If txtNames.Text = Player1Name Or txtNames.Text = Player2Name Or txtNames.Text = Player3Name Or txtNames.Text = Player4Name Or txtNames.Text = Player5Name Then
                            MsgBox("Numele asta e deja folosit.")
                        ElseIf txtNames.Text <> Player1Name Or txtNames.Text <> Player2Name Or txtNames.Text <> Player3Name Or txtNames.Text <> Player4Name Or txtNames.Text <> Player5Name Then
                            Player6Color = culoare
                            Me.dgv1.Columns(16).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(17).DefaultCellStyle.BackColor = culoare
                            Me.dgv1.Columns(18).DefaultCellStyle.BackColor = culoare
                            Player6Name = txtNames.Text
                            dgv1.Columns(16).HeaderText = Player6Name  'scrie numele in dgv header
                            Listbox1.Items.Add("Nume Player6: " & Player6Name) 'adauga mesaj in listbox
                            Listbox1.Items.Add(culoare.ToString) 'adauga mesaj in listbox
                            txtNames.Clear()         'sterge textbox
                            Player6NameTurn = False
                            Player1NameTurn = True
                            DisableColors() 'Check and Disable Used Colors
                            GroupBoxNameColor.Visible = False
                            btnStartNextRound.Enabled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    'btnNewGame
    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        'clear dgv
        dgv1.Rows.Clear()
        'make panel charts invisible
        PanelCharts.Visible = False
        'make timer panel invisible
        GroupBoxTimer.Visible = False
        lblPlayerSeconds.Visible = False

        btnStartNextRound.Enabled = True
        ResetTimers() 'Reset Timers
        row = 0 'Reset row = 0
        cRoundIndex = 0 'reset cround = 0
        CurrentPlayerQueue.Clear() 'reset curentplayerqueue
        NextPlayerQueue.Clear() 'reset nextplayerqueue
        DealerQueue.Clear() 'reset dealerqueue
        Listbox1.Items.Clear() 'clear listbox

        ChartPoints.Series(0).Points.Clear()
        ChartTime.Series(0).Points.Clear()

        'Clear Color off Dealer Name
        Me.dgv1.Columns(1).HeaderCell.Style.ForeColor = Color.Empty
        Me.dgv1.Columns(4).HeaderCell.Style.ForeColor = Color.Empty
        Me.dgv1.Columns(7).HeaderCell.Style.ForeColor = Color.Empty
        Me.dgv1.Columns(10).HeaderCell.Style.ForeColor = Color.Empty
        Me.dgv1.Columns(13).HeaderCell.Style.ForeColor = Color.Empty
        Me.dgv1.Columns(16).HeaderCell.Style.ForeColor = Color.Empty
        'Loading Main Form again
        Form1_Load(Me, New System.EventArgs)
    End Sub

    'btnStergeRunda
    Private Sub btnStergeRunda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStergeRunda.Click
        Me.dgv1.Rows.Remove(dgv1.Rows(row)) 'remove row
        row -= 1 'go back 1 row
        cRoundIndex -= 1 'go back 1 index in cRound

        DealerQueue.Enqueue(DealerStack.Pop) 'scoate la suprafata ultimul dealer folosit
        CurrentDealer = DealerStack.Peek     'Dealerul = ultimul dealer
        HighlightDealer()                    'Coloreaza cu rosu dealerul

        NextPlayerQueue.Enqueue(NextPlayerStack.Pop)
        CurrentPlayerQueue.Enqueue(CurrentPlayerStack.Pop)
        NextPlayer = NextPlayerStack.Peek
        CurrentPlayer = CurrentPlayerStack.Peek

        Listbox1.Items.Add(CurrentPlayer & " Sters Runda ")
        Listbox1.Items.Add(NextPlayer & " Sters Runda ")
        Listbox1.TopIndex = Listbox1.Items.Count - 1
        HighlightNextPlayer()

        ListboxMsg()

        btnStergeRunda.Enabled = False
    End Sub

#End Region

#Region "Button Start End Update"
    'btnStartNextRound
    Private Sub btnStartNextRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartNextRound.Click
        'Increase row Value to go to Next DGV row
        row += 1
        'Enalbe timers
        GroupBoxTimer.Visible = True
        lblPlayerSeconds.Visible = True

        Timer1.Enabled = True
        Timer2.Enabled = True
        'Update Labels
        lblRow.Text = "Current Row: " & row
        lblRound.Text = "Current Round: " & cRound
        Listbox1.Items.Add("+++ Runda " & row & " +++")
        Listbox1.Items.Add(".....................")
        Listbox1.TopIndex = Listbox1.Items.Count - 1
        'Check Total Number of Players and Loop Players and Dealer
        If TotalPlayers = 4 Then
            LoadCurrentAndNextPlayer()
            DealerTurnx4()
        ElseIf TotalPlayers = 5 Then
            LoadCurrentAndNextPlayer()
            DealerTurnx5()
        ElseIf TotalPlayers = 6 Then
            LoadCurrentAndNextPlayer()
            DealerTurnx6()
        End If
        'Enable: GroupBox 'Disable: StartNextRound, btnStergeRunda
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
        'System Window Message for Start Bid si Cine le face
        Listbox1.Items.Add("Le face " & CurrentDealer)
        Listbox1.Items.Add("Liciteaza " & CurrentPlayer)
        Listbox1.TopIndex = Listbox1.Items.Count - 1
        lblcRoundindex.Text = ("cRoundIndex: " & cRoundIndex)
        'Highlight Curent Player Header column
        HighlightCurrentPlayer()
        HighlightDealer()
        'Disable Sterge Runda
        btnStergeRunda.Enabled = False
        TimerToolStripMenuItem.Enabled = True
        TimerToolStripMenuItem.Checked = True
    End Sub
    'btnEndRound
    Private Sub btnEndRoundScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndRoundScore.Click
        'Check Total Number of Players and Loop Players and Dealer
        LoadCurrentAndNextPlayer()
        'Enable Groupbox1
        GroupBox1.Enabled = True
        'Disable btnEndRoundScore
        btnEndRoundScore.Enabled = False
        'Declare Endround Truen and BidRound False
        BidRound = False
        EndRound = True
        'Declare Round Ended and Start EndRound
        Listbox1.Items.Add("+++ Rezultate Runda " & row & " +++")
        Listbox1.Items.Add(".....................")
        Listbox1.Items.Add("Cate a facut " & CurrentPlayer & " ?")
        Listbox1.TopIndex = Listbox1.Items.Count - 1
        'Enable only the buttons for the curent round
        ifRoundEnableButton()
        'Highlight Curent Player Header column
        HighlightCurrentPlayer()
    End Sub
    'btnUpdateScore
    Private Sub btnUpdScore_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdScore.Click
        'Check if TotalEndBid matches cRound and if different display message
        If dgv1.Rows(row).Cells(20).Value = cRound Then
            'Loop Current and Next Player
            NextPlayerStack.Push(NextPlayerQueue.Dequeue())
            CurrentPlayerStack.Push(CurrentPlayerQueue.Dequeue())

            DealerStack.Push(DealerQueue.Dequeue())

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
        'Enable btnStartNextRound
        'Disable GroupBox1, btnEndRoundScore, btn UpdateScore
        btnStartNextRound.Enabled = True
        GroupBox1.Enabled = False
        btnEndRoundScore.Enabled = False
        btnUpdScore.Enabled = False
        btnStergeRunda.Enabled = True
        'Update Scores in DGV
        dgv1.Rows(row).Cells(1).Value = ScorP1()
        dgv1.Rows(row).Cells(4).Value = ScorP2()
        dgv1.Rows(row).Cells(7).Value = ScorP3()
        dgv1.Rows(row).Cells(10).Value = ScorP4()
        dgv1.Rows(row).Cells(13).Value = ScorP5()
        dgv1.Rows(row).Cells(16).Value = ScorP6()
        'System Window Message to announce Scores Round
        Listbox1.Items.Add("+++ Scorul Runda " & row & " +++")
        Listbox1.Items.Add(".....................")
        Listbox1.TopIndex = Listbox1.Items.Count - 1
        WinCondition()
    End Sub
#End Region

#Region "Timers"
    'Timer1 Tick (Hours minutes seconds)
    Private Sub Timer1_Tick_1(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        If lblSeconds.Text = 59 Then
            lblSeconds.Text = 0
            lblMinutes.Text = lblMinutes.Text + 1
        ElseIf lblSeconds.Text >= 0 Then
            lblSeconds.Text = lblSeconds.Text + 1
        End If
        If lblMinutes.Text = 60 Then
            lblHours.Text = lblSeparator2.Text + 1
            lblMinutes.Text = 0
        End If
    End Sub
    'Timer2 Tick (player seconds)
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer2.Tick
        If lblPlayerSeconds.Text >= 0 Then
            lblPlayerSeconds.Text = lblPlayerSeconds.Text + 1
        End If
    End Sub
    'Ia timpul dintre doua biduri si il pune in lblTimeStamp pentru fiecare player daca e BidRound
    Private Sub TimeCheck()
        Dim TimeStamp As Integer = lblPlayerSeconds.Text

        If BidRound Then
            If CurrentPlayer = Player1Name Then
                dgv1.Rows(row).Cells(21).Value = dgv1.Rows(row - 1).Cells(21).Value + TimeStamp
            ElseIf CurrentPlayer = Player2Name Then
                dgv1.Rows(row).Cells(22).Value = dgv1.Rows(row - 1).Cells(22).Value + TimeStamp
            ElseIf CurrentPlayer = Player3Name Then
                dgv1.Rows(row).Cells(23).Value = dgv1.Rows(row - 1).Cells(23).Value + TimeStamp
            ElseIf CurrentPlayer = Player4Name Then
                dgv1.Rows(row).Cells(24).Value = dgv1.Rows(row - 1).Cells(24).Value + TimeStamp
            ElseIf CurrentPlayer = Player5Name Then
                dgv1.Rows(row).Cells(25).Value = dgv1.Rows(row - 1).Cells(25).Value + TimeStamp
            ElseIf CurrentPlayer = Player6Name Then
                dgv1.Rows(row).Cells(26).Value = dgv1.Rows(row - 1).Cells(26).Value + TimeStamp
            End If
            lblPlayerSeconds.Text = 0
        End If
    End Sub
    'Reset Timer Labels
    Private Sub ResetTimers()
        lblHours.Text = 0
        lblMinutes.Text = 0
        lblSeconds.Text = 0
        lblPlayerSeconds.Text = 0
    End Sub
#End Region

#Region "Menu"
    'Menu_About
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Whist" & Environment.NewLine & "Version 1.1" & Environment.NewLine & "Copyright © 2014" & Environment.NewLine & Environment.NewLine & "All Rights Reserved" & Environment.NewLine & "by Cristian Muscalu", "About Whist")
    End Sub
    'Menu_Exit
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    'Menu_Arhiva
    Private Sub ArhivaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArhivaToolStripMenuItem.Click
        'Archive Visible/Invisible
        If ArhivaToolStripMenuItem.Checked = True Then
            GroupBox3.Visible = False
            ArhivaToolStripMenuItem.Checked = False
        ElseIf ArhivaToolStripMenuItem.Checked = False Then
            GroupBox3.Visible = True
            ArhivaToolStripMenuItem.Checked = True
        End If

        'Resize DGV to cover/uncover the ListBox
        If dgv1.Width = 1014 Then
            dgv1.Width = 1224
            ArhivaToolStripMenuItem.Checked = False
        ElseIf dgv1.Width = 1224 Then
            dgv1.Width = 1014
            ArhivaToolStripMenuItem.Checked = True
        End If
    End Sub
    'Menu_Timer Show/Hide Timer
    Private Sub TimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerToolStripMenuItem.Click
        If TimerToolStripMenuItem.Checked = True Then
            GroupBoxTimer.Visible = False
            TimerToolStripMenuItem.Checked = False
        ElseIf TimerToolStripMenuItem.Checked = False Then
            GroupBoxTimer.Visible = True
            TimerToolStripMenuItem.Checked = True
        End If
    End Sub
#End Region

#Region "End Game"
    'End Game WinCondition
    Private Sub WinCondition()
        If TotalPlayers = 4 Then
            If cRoundIndex = 0 And row >= 2 Then
                btnStartNextRound.Enabled = False
                Check4Win()
                ExportExcel()
                btnNewGame.Visible = True
            End If
        ElseIf TotalPlayers = 5 Then
            If cRoundIndex = 0 And row >= 2 Then
                btnStartNextRound.Enabled = False
                Check5Win()
                ExportExcel()
                btnNewGame.Visible = True
            End If
        ElseIf TotalPlayers = 6 Then
            If cRoundIndex = 0 And row >= 2 Then
                btnStartNextRound.Enabled = False
                Check6Win()
                ExportExcel()
                btnNewGame.Visible = True
            End If
        End If
    End Sub
    'Check if 4 Win
    Private Sub Check4Win()

        Dim Player1WinCell = dgv1.Rows(24).Cells(1).Value 'rows (24 for end)
        Dim Player2WinCell = dgv1.Rows(24).Cells(4).Value
        Dim Player3WinCell = dgv1.Rows(24).Cells(7).Value
        Dim Player4WinCell = dgv1.Rows(24).Cells(10).Value

        'Victoria #2
        PanelCharts.Visible = True
        btnStergeRunda.Enabled = False
        Timer1.Enabled = False

        ChartPoints.Series("Points").Points.AddXY(Player1Name, dgv1.Rows(24).Cells(1).Value)
        ChartPoints.Series("Points").Points(0).Color = Player1Color
        ChartPoints.Series("Points").Points(0).Label = Player1Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player2Name, dgv1.Rows(24).Cells(4).Value)
        ChartPoints.Series("Points").Points(1).Color = Player2Color
        ChartPoints.Series("Points").Points(1).Label = Player2Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player3Name, dgv1.Rows(24).Cells(7).Value)
        ChartPoints.Series("Points").Points(2).Color = Player3Color
        ChartPoints.Series("Points").Points(2).Label = Player3Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player4Name, dgv1.Rows(24).Cells(10).Value)
        ChartPoints.Series("Points").Points(3).Color = Player4Color
        ChartPoints.Series("Points").Points(3).Label = Player4Name & " (#VAL pct)"

        ChartTime.Series("Time").Points.AddXY(Player1Name, dgv1.Rows(24).Cells(21).Value)
        ChartTime.Series("Time").Points(0).Color = Player1Color
        ChartTime.Series("Time").Points(0).Label = Player1Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player2Name, dgv1.Rows(24).Cells(22).Value)
        ChartTime.Series("Time").Points(1).Color = Player2Color
        ChartTime.Series("Time").Points(1).Label = Player2Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player3Name, dgv1.Rows(24).Cells(23).Value)
        ChartTime.Series("Time").Points(2).Color = Player3Color
        ChartTime.Series("Time").Points(2).Label = Player3Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player4Name, dgv1.Rows(24).Cells(24).Value)
        ChartTime.Series("Time").Points(3).Color = Player4Color
        ChartTime.Series("Time").Points(3).Label = Player4Name & " (#VAL sec)"

        'Un singur Castigator
        If Player1WinCell > Player2WinCell And Player1WinCell > Player3WinCell And Player1WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player1Name & " !")
            lblCastigator.ForeColor = Player1Color
        ElseIf Player2WinCell > Player1WinCell And Player2WinCell > Player3WinCell And Player2WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player2Name & " !")
            lblCastigator.ForeColor = Player2Color
        ElseIf Player3WinCell > Player1WinCell And Player3WinCell > Player2WinCell And Player3WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player3Name & " !")
            lblCastigator.ForeColor = Player3Color
        ElseIf Player4WinCell > Player1WinCell And Player4WinCell > Player2WinCell And Player4WinCell > Player3WinCell Then
            lblCastigator.Text = ("Felicitari " & Player4Name & " !")
            lblCastigator.ForeColor = Player4Color
            'Egalitate intre  3
        ElseIf Player1WinCell = Player2WinCell = Player3WinCell Then '1,2,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player3Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player4WinCell Then '1,3,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player4Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player4WinCell Then '1,2,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player4Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player4WinCell Then '2,3,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player4Name & " !")
            'Egalitate intre  2
            'Egalitate intre  2
        ElseIf Player1WinCell = Player2WinCell Then '1,2
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & " !")
        ElseIf Player1WinCell = Player3WinCell Then '1,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & " !")
        ElseIf Player1WinCell = Player4WinCell Then '1,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player4Name & " !")
        ElseIf Player2WinCell = Player3WinCell Then '2,3
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & " !")
        ElseIf Player2WinCell = Player4WinCell Then '2,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player4Name & " !")
        ElseIf Player3WinCell = Player4WinCell Then '3,4
            lblCastigator.Text = ("Egalitate intre " & Player3Name & " si " & Player4Name & " !")
        End If

        'Disable btnStergeRunda
        btnStergeRunda.Enabled = False
    End Sub
    'Check if 5 Win
    Private Sub Check5Win()
        Dim Player1WinCell = dgv1.Rows(27).Cells(1).Value 'row 27 for end
        Dim Player2WinCell = dgv1.Rows(27).Cells(4).Value
        Dim Player3WinCell = dgv1.Rows(27).Cells(7).Value
        Dim Player4WinCell = dgv1.Rows(27).Cells(10).Value
        Dim Player5WinCell = dgv1.Rows(27).Cells(13).Value

        'Victoria #2
        PanelCharts.Visible = True
        btnStergeRunda.Enabled = False
        Timer1.Enabled = False

        ChartPoints.Series("Points").Points.AddXY(Player1Name, dgv1.Rows(27).Cells(1).Value)
        ChartPoints.Series("Points").Points(0).Color = Player1Color
        ChartPoints.Series("Points").Points(0).Label = Player1Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player2Name, dgv1.Rows(27).Cells(4).Value)
        ChartPoints.Series("Points").Points(1).Color = Player2Color
        ChartPoints.Series("Points").Points(1).Label = Player2Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player3Name, dgv1.Rows(27).Cells(7).Value)
        ChartPoints.Series("Points").Points(2).Color = Player3Color
        ChartPoints.Series("Points").Points(2).Label = Player3Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player4Name, dgv1.Rows(27).Cells(10).Value)
        ChartPoints.Series("Points").Points(3).Color = Player4Color
        ChartPoints.Series("Points").Points(3).Label = Player4Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player5Name, dgv1.Rows(27).Cells(13).Value)
        ChartPoints.Series("Points").Points(4).Color = Player5Color
        ChartPoints.Series("Points").Points(4).Label = Player5Name & " (#VAL pct)"
        ChartTime.Series("Time").Points.AddXY(Player1Name, dgv1.Rows(27).Cells(21).Value)
        ChartTime.Series("Time").Points(0).Color = Player1Color
        ChartTime.Series("Time").Points(0).Label = Player1Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player2Name, dgv1.Rows(27).Cells(22).Value)
        ChartTime.Series("Time").Points(1).Color = Player2Color
        ChartTime.Series("Time").Points(1).Label = Player2Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player3Name, dgv1.Rows(27).Cells(23).Value)
        ChartTime.Series("Time").Points(2).Color = Player3Color
        ChartTime.Series("Time").Points(2).Label = Player3Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player4Name, dgv1.Rows(27).Cells(24).Value)
        ChartTime.Series("Time").Points(3).Color = Player4Color
        ChartTime.Series("Time").Points(3).Label = Player4Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player5Name, dgv1.Rows(27).Cells(25).Value)
        ChartTime.Series("Time").Points(4).Color = Player5Color
        ChartTime.Series("Time").Points(4).Label = Player5Name & " (#VAL sec)"

        'Un singur Castigator
        If Player1WinCell > Player2WinCell And Player1WinCell > Player3WinCell And Player1WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player1Name & " !")
            lblCastigator.ForeColor = Player1Color
        ElseIf Player2WinCell > Player1WinCell And Player2WinCell > Player3WinCell And Player2WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player2Name & " !")
            lblCastigator.ForeColor = Player2Color
        ElseIf Player3WinCell > Player1WinCell And Player3WinCell > Player2WinCell And Player3WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player3Name & " !")
            lblCastigator.ForeColor = Player3Color
        ElseIf Player4WinCell > Player1WinCell And Player4WinCell > Player2WinCell And Player4WinCell > Player3WinCell Then
            lblCastigator.Text = ("Felicitari " & Player4Name & " !")
            lblCastigator.ForeColor = Player4Color
        ElseIf Player5WinCell > Player1WinCell And Player5WinCell > Player2WinCell And Player5WinCell > Player3WinCell And Player5WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player5Name & " !")
            lblCastigator.ForeColor = Player5Color
            'Egalitate intre  3
        ElseIf Player1WinCell = Player2WinCell = Player3WinCell Then '1,2,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player3Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player4WinCell Then '1,2,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player4Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player5WinCell Then '1,2,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player5Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player4WinCell Then '1,3,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player4Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player5WinCell Then '1,3,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player5Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player4WinCell Then '2,3,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player4Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player5WinCell Then '2,3,5
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player5Name & " !")
        ElseIf Player2WinCell = Player4WinCell = Player5WinCell Then '2,4,5
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player4Name & ", " & Player5Name & " !")
            'Egalitate intre  2
        ElseIf Player1WinCell = Player2WinCell Then '1,2
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & " !")
        ElseIf Player1WinCell = Player3WinCell Then '1,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & " !")
        ElseIf Player1WinCell = Player4WinCell Then '1,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player4Name & " !")
        ElseIf Player1WinCell = Player5WinCell Then '1,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player5Name & " !")
        ElseIf Player2WinCell = Player3WinCell Then '2,3
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & " !")
        ElseIf Player2WinCell = Player4WinCell Then '2,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player4Name & " !")
        ElseIf Player2WinCell = Player5WinCell Then '2,5
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player5Name & " !")
        ElseIf Player3WinCell = Player4WinCell Then '3,4
            lblCastigator.Text = ("Egalitate intre " & Player3Name & " si " & Player4Name & " !")
        ElseIf Player3WinCell = Player5WinCell Then '3,5
            lblCastigator.Text = ("Egalitate intre " & Player3Name & " si " & Player5Name & " !")
        End If

        'Disable btnStergeRunda
        btnStergeRunda.Enabled = False
    End Sub
    'Check if 6 Win
    Private Sub Check6Win()
        Dim Player1WinCell = dgv1.Rows(30).Cells(1).Value
        Dim Player2WinCell = dgv1.Rows(30).Cells(4).Value
        Dim Player3WinCell = dgv1.Rows(30).Cells(7).Value
        Dim Player4WinCell = dgv1.Rows(30).Cells(10).Value
        Dim Player5WinCell = dgv1.Rows(30).Cells(13).Value
        Dim Player6WinCell = dgv1.Rows(30).Cells(16).Value

        'Victoria #2
        PanelCharts.Visible = True
        btnStergeRunda.Enabled = False
        Timer1.Enabled = False

        ChartPoints.Series("Points").Points.AddXY(Player1Name, dgv1.Rows(30).Cells(1).Value)
        ChartPoints.Series("Points").Points(0).Color = Player1Color
        ChartPoints.Series("Points").Points(0).Label = Player1Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player2Name, dgv1.Rows(30).Cells(4).Value)
        ChartPoints.Series("Points").Points(1).Color = Player2Color
        ChartPoints.Series("Points").Points(1).Label = Player2Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player3Name, dgv1.Rows(30).Cells(7).Value)
        ChartPoints.Series("Points").Points(2).Color = Player3Color
        ChartPoints.Series("Points").Points(2).Label = Player3Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player4Name, dgv1.Rows(30).Cells(10).Value)
        ChartPoints.Series("Points").Points(3).Color = Player4Color
        ChartPoints.Series("Points").Points(3).Label = Player4Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player5Name, dgv1.Rows(30).Cells(13).Value)
        ChartPoints.Series("Points").Points(4).Color = Player5Color
        ChartPoints.Series("Points").Points(4).Label = Player5Name & " (#VAL pct)"
        ChartPoints.Series("Points").Points.AddXY(Player6Name, dgv1.Rows(30).Cells(16).Value)
        ChartPoints.Series("Points").Points(5).Color = Player6Color
        ChartPoints.Series("Points").Points(5).Label = Player6Name & " (#VAL pct)"

        ChartTime.Series("Time").Points.AddXY(Player1Name, dgv1.Rows(30).Cells(21).Value)
        ChartTime.Series("Time").Points(0).Color = Player1Color
        ChartTime.Series("Time").Points(0).Label = Player1Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player2Name, dgv1.Rows(30).Cells(22).Value)
        ChartTime.Series("Time").Points(1).Color = Player2Color
        ChartTime.Series("Time").Points(1).Label = Player2Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player3Name, dgv1.Rows(30).Cells(23).Value)
        ChartTime.Series("Time").Points(2).Color = Player3Color
        ChartTime.Series("Time").Points(2).Label = Player3Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player4Name, dgv1.Rows(30).Cells(24).Value)
        ChartTime.Series("Time").Points(3).Color = Player4Color
        ChartTime.Series("Time").Points(3).Label = Player4Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player5Name, dgv1.Rows(30).Cells(25).Value)
        ChartTime.Series("Time").Points(4).Color = Player5Color
        ChartTime.Series("Time").Points(4).Label = Player5Name & " (#VAL sec)"
        ChartTime.Series("Time").Points.AddXY(Player6Name, dgv1.Rows(30).Cells(26).Value)
        ChartTime.Series("Time").Points(5).Color = Player6Color
        ChartTime.Series("Time").Points(5).Label = Player6Name & " (#VAL sec)"

        'Un singur Castigator
        If Player1WinCell > Player2WinCell And Player1WinCell > Player3WinCell And Player1WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player1Name & " !")
            lblCastigator.ForeColor = Player1Color
        ElseIf Player2WinCell > Player1WinCell And Player2WinCell > Player3WinCell And Player2WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player2Name & " !")
            lblCastigator.ForeColor = Player2Color
        ElseIf Player3WinCell > Player1WinCell And Player3WinCell > Player2WinCell And Player3WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player3Name & " !")
            lblCastigator.ForeColor = Player3Color
        ElseIf Player4WinCell > Player1WinCell And Player4WinCell > Player2WinCell And Player4WinCell > Player3WinCell Then
            lblCastigator.Text = ("Felicitari " & Player4Name & " !")
            lblCastigator.ForeColor = Player4Color
        ElseIf Player5WinCell > Player1WinCell And Player5WinCell > Player2WinCell And Player5WinCell > Player3WinCell And _
            Player5WinCell > Player4WinCell Then
            lblCastigator.Text = ("Felicitari " & Player5Name & " !")
            lblCastigator.ForeColor = Player5Color
        ElseIf Player6WinCell > Player1WinCell And Player6WinCell > Player2WinCell And Player6WinCell > Player3WinCell And _
            Player6WinCell > Player4WinCell And Player6WinCell > Player5WinCell Then
            lblCastigator.Text = ("Felicitari " & Player6Name & " !")
            lblCastigator.ForeColor = Player6Color
            'Egalitate intre  3
        ElseIf Player1WinCell = Player2WinCell = Player3WinCell Then '1,2,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player3Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player4WinCell Then '1,2,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player4Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player5WinCell Then '1,2,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player5Name & " !")
        ElseIf Player1WinCell = Player2WinCell = Player6WinCell Then '1,2,6
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & ", " & Player6Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player4WinCell Then '1,3,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player4Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player5WinCell Then '1,3,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player5Name & " !")
        ElseIf Player1WinCell = Player3WinCell = Player6WinCell Then '1,3,6
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & ", " & Player6Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player4WinCell Then '2,3,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player4Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player5WinCell Then '2,3,5
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player5Name & " !")
        ElseIf Player2WinCell = Player3WinCell = Player6WinCell Then '2,3,6
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & ", " & Player6Name & " !")
        ElseIf Player2WinCell = Player4WinCell = Player6WinCell Then '2,4,6
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player4Name & ", " & Player6Name & " !")
        ElseIf Player2WinCell = Player5WinCell = Player6WinCell Then '2,5,6
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player5Name & ", " & Player6Name & " !")
            'Egalitate intre  2
        ElseIf Player1WinCell = Player2WinCell Then '1,2
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player2Name & " !")
        ElseIf Player1WinCell = Player3WinCell Then '1,3
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player3Name & " !")
        ElseIf Player1WinCell = Player4WinCell Then '1,4
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player4Name & " !")
        ElseIf Player1WinCell = Player5WinCell Then '1,5
            lblCastigator.Text = ("Egalitate intre " & Player1Name & " si " & Player5Name & " !")
        ElseIf Player2WinCell = Player3WinCell Then '2,3
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player3Name & " !")
        ElseIf Player2WinCell = Player4WinCell Then '2,4
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player4Name & " !")
        ElseIf Player2WinCell = Player5WinCell Then '2,5
            lblCastigator.Text = ("Egalitate intre " & Player2Name & " si " & Player5Name & " !")
        ElseIf Player3WinCell = Player4WinCell Then '3,4
            lblCastigator.Text = ("Egalitate intre " & Player3Name & " si " & Player4Name & " !")
        ElseIf Player3WinCell = Player5WinCell Then '3,5
            lblCastigator.Text = ("Egalitate intre " & Player3Name & " si " & Player5Name & " !")
        End If

        'Disable btnStergeRunda
        btnStergeRunda.Enabled = False
    End Sub
    'Excel
    Private Sub ExportExcel()
        Dim ExcelApp As Object, ExcelBook As Object
        Dim ExcelSheet As Object
        Dim n As Integer
        Dim Coloane As Integer
        'create object of excel
        ExcelApp = CreateObject("Excel.Application")
        ExcelBook = ExcelApp.WorkBooks.Add
        ExcelSheet = ExcelBook.WorkSheets(1)

        If TotalPlayers = 4 Then Coloane = 12
        If TotalPlayers = 5 Then Coloane = 15
        If TotalPlayers = 6 Then Coloane = 18
        With ExcelSheet
            For n = 1 To Coloane
                'Type Time and Date to 1-st Row
                .cells(1, 1) = ("Jucat in data de: " & fileDateTime)
                'Export Name Columns and Styles
                .Cells(2, n) = dgv1.Columns(n).HeaderText
                .Rows(2).Font.FontStyle = "Bold"
                .Rows(2).Font.Size = 16
                .Rows(2).Font.Color = Color.Red
                'Export Scores and Bids
                If TotalPlayers = 4 Then
                    .Cells(3, n) = dgv1.Rows(1).Cells(n).Value
                    .Cells(4, n) = dgv1.Rows(2).Cells(n).Value
                    .Cells(5, n) = dgv1.Rows(3).Cells(n).Value
                    .Cells(6, n) = dgv1.Rows(4).Cells(n).Value
                    .Cells(7, n) = dgv1.Rows(5).Cells(n).Value
                    .Cells(8, n) = dgv1.Rows(6).Cells(n).Value
                    .Cells(9, n) = dgv1.Rows(7).Cells(n).Value
                    .Cells(10, n) = dgv1.Rows(8).Cells(n).Value
                    .Cells(11, n) = dgv1.Rows(9).Cells(n).Value
                    .Cells(12, n) = dgv1.Rows(10).Cells(n).Value
                    .Cells(13, n) = dgv1.Rows(11).Cells(n).Value
                    .Cells(14, n) = dgv1.Rows(12).Cells(n).Value
                    .Cells(15, n) = dgv1.Rows(13).Cells(n).Value
                    .Cells(16, n) = dgv1.Rows(14).Cells(n).Value
                    .Cells(17, n) = dgv1.Rows(15).Cells(n).Value
                    .Cells(18, n) = dgv1.Rows(16).Cells(n).Value
                    .Cells(19, n) = dgv1.Rows(17).Cells(n).Value
                    .Cells(20, n) = dgv1.Rows(18).Cells(n).Value
                    .Cells(21, n) = dgv1.Rows(19).Cells(n).Value
                    .Cells(22, n) = dgv1.Rows(20).Cells(n).Value
                    .Cells(23, n) = dgv1.Rows(21).Cells(n).Value
                    .Cells(24, n) = dgv1.Rows(22).Cells(n).Value
                    .Cells(25, n) = dgv1.Rows(23).Cells(n).Value
                    .Cells(26, n) = dgv1.Rows(24).Cells(n).Value
                ElseIf TotalPlayers = 5 Then
                    .Cells(3, n) = dgv1.Rows(1).Cells(n).Value
                    .Cells(4, n) = dgv1.Rows(2).Cells(n).Value
                    .Cells(5, n) = dgv1.Rows(3).Cells(n).Value
                    .Cells(6, n) = dgv1.Rows(4).Cells(n).Value
                    .Cells(7, n) = dgv1.Rows(5).Cells(n).Value
                    .Cells(8, n) = dgv1.Rows(6).Cells(n).Value
                    .Cells(9, n) = dgv1.Rows(7).Cells(n).Value
                    .Cells(10, n) = dgv1.Rows(8).Cells(n).Value
                    .Cells(11, n) = dgv1.Rows(9).Cells(n).Value
                    .Cells(12, n) = dgv1.Rows(10).Cells(n).Value
                    .Cells(13, n) = dgv1.Rows(11).Cells(n).Value
                    .Cells(14, n) = dgv1.Rows(12).Cells(n).Value
                    .Cells(15, n) = dgv1.Rows(13).Cells(n).Value
                    .Cells(16, n) = dgv1.Rows(14).Cells(n).Value
                    .Cells(17, n) = dgv1.Rows(15).Cells(n).Value
                    .Cells(18, n) = dgv1.Rows(16).Cells(n).Value
                    .Cells(19, n) = dgv1.Rows(17).Cells(n).Value
                    .Cells(20, n) = dgv1.Rows(18).Cells(n).Value
                    .Cells(21, n) = dgv1.Rows(19).Cells(n).Value
                    .Cells(22, n) = dgv1.Rows(20).Cells(n).Value
                    .Cells(23, n) = dgv1.Rows(21).Cells(n).Value
                    .Cells(24, n) = dgv1.Rows(22).Cells(n).Value
                    .Cells(25, n) = dgv1.Rows(23).Cells(n).Value
                    .Cells(26, n) = dgv1.Rows(24).Cells(n).Value
                    .Cells(27, n) = dgv1.Rows(25).Cells(n).Value
                    .Cells(28, n) = dgv1.Rows(26).Cells(n).Value
                    .Cells(29, n) = dgv1.Rows(27).Cells(n).Value
                ElseIf TotalPlayers = 6 Then
                    .Cells(3, n) = dgv1.Rows(1).Cells(n).Value
                    .Cells(4, n) = dgv1.Rows(2).Cells(n).Value
                    .Cells(5, n) = dgv1.Rows(3).Cells(n).Value
                    .Cells(6, n) = dgv1.Rows(4).Cells(n).Value
                    .Cells(7, n) = dgv1.Rows(5).Cells(n).Value
                    .Cells(8, n) = dgv1.Rows(6).Cells(n).Value
                    .Cells(9, n) = dgv1.Rows(7).Cells(n).Value
                    .Cells(10, n) = dgv1.Rows(8).Cells(n).Value
                    .Cells(11, n) = dgv1.Rows(9).Cells(n).Value
                    .Cells(12, n) = dgv1.Rows(10).Cells(n).Value
                    .Cells(13, n) = dgv1.Rows(11).Cells(n).Value
                    .Cells(14, n) = dgv1.Rows(12).Cells(n).Value
                    .Cells(15, n) = dgv1.Rows(13).Cells(n).Value
                    .Cells(16, n) = dgv1.Rows(14).Cells(n).Value
                    .Cells(17, n) = dgv1.Rows(15).Cells(n).Value
                    .Cells(18, n) = dgv1.Rows(16).Cells(n).Value
                    .Cells(19, n) = dgv1.Rows(17).Cells(n).Value
                    .Cells(20, n) = dgv1.Rows(18).Cells(n).Value
                    .Cells(21, n) = dgv1.Rows(19).Cells(n).Value
                    .Cells(22, n) = dgv1.Rows(20).Cells(n).Value
                    .Cells(23, n) = dgv1.Rows(21).Cells(n).Value
                    .Cells(24, n) = dgv1.Rows(22).Cells(n).Value
                    .Cells(25, n) = dgv1.Rows(20).Cells(n).Value
                    .Cells(26, n) = dgv1.Rows(21).Cells(n).Value
                    .Cells(27, n) = dgv1.Rows(22).Cells(n).Value
                    .Cells(28, n) = dgv1.Rows(23).Cells(n).Value
                    .Cells(29, n) = dgv1.Rows(24).Cells(n).Value
                    .Cells(30, n) = dgv1.Rows(25).Cells(n).Value
                    .Cells(28, n) = dgv1.Rows(26).Cells(n).Value
                    .Cells(29, n) = dgv1.Rows(27).Cells(n).Value
                    .Cells(30, n) = dgv1.Rows(28).Cells(n).Value
                    .Cells(31, n) = dgv1.Rows(29).Cells(n).Value
                    .Cells(32, n) = dgv1.Rows(30).Cells(n).Value
                End If

                'Deacrese Size of Bid Columns
                .Cells.Columns(2).AutoFit()
                .Cells.Columns(3).AutoFit()
                .Cells.Columns(5).AutoFit()
                .Cells.Columns(6).AutoFit()
                .Cells.Columns(8).AutoFit()
                .Cells.Columns(9).AutoFit()
                .Cells.Columns(11).AutoFit()
                .Cells.Columns(12).AutoFit()
                .Cells.Columns(14).AutoFit()
                .Cells.Columns(15).AutoFit()
                .Cells.Columns(17).AutoFit()
                .Cells.Columns(18).AutoFit()
            Next
        End With

        Dim res As MsgBoxResult
        res = MsgBox("Joc salvat in Folderul D:\Whist. Vrei sa vezi?", MsgBoxStyle.YesNo)
        My.Computer.FileSystem.CreateDirectory("D:\Whist")

        If TotalPlayers = 4 Then
            ExcelSheet.SaveAs("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & "-" & fileDateTime & ".xlsx")
            If (res = MsgBoxResult.Yes) Then
                Process.Start("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & "-" & fileDateTime & ".xlsx")
            End If
        ElseIf TotalPlayers = 5 Then
            ExcelSheet.SaveAs("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & Player5Name & "-" & fileDateTime & ".xlsx")
            If (res = MsgBoxResult.Yes) Then
                Process.Start("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & Player5Name & "-" & fileDateTime & ".xlsx")
            End If
        ElseIf TotalPlayers = 6 Then
            ExcelSheet.SaveAs("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & Player5Name & Player6Name & "-" & fileDateTime & ".xlsx")
            If (res = MsgBoxResult.Yes) Then
                Process.Start("D:\Whist\Whist-" & Player1Name & "-" & Player2Name & "-" & Player3Name & "-" & Player4Name & Player5Name & Player6Name & "-" & fileDateTime & ".xlsx")
            End If
        End If

        ExcelSheet = Nothing
        ExcelBook = Nothing
        ExcelApp = Nothing
    End Sub
#End Region


#Region "TESTE"
    'Premiere in + sau - (IN TESTE)
    Private Sub Premiere()
        Dim Strike1 As Boolean = True = dgv1.Rows(row).Cells(2).Style.Font.Strikeout
        Dim Strike2 As Boolean = True = dgv1.Rows(row - 1).Cells(2).Style.Font.Strikeout
        Dim Strike3 As Boolean = True = dgv1.Rows(row - 2).Cells(2).Style.Font.Strikeout
        Dim Strike4 As Boolean = True = dgv1.Rows(row - 3).Cells(2).Style.Font.Strikeout
        Dim Strike5 As Boolean = True = dgv1.Rows(row - 4).Cells(2).Style.Font.Strikeout

        Dim cRound1 As Integer = dgv1.Rows(row - 1).Cells(0).Value
        Dim cRound2 As Integer = dgv1.Rows(row - 2).Cells(0).Value
        Dim cRound3 As Integer = dgv1.Rows(row - 3).Cells(0).Value
        Dim cRound4 As Integer = dgv1.Rows(row - 4).Cells(0).Value
        Dim cRound5 As Integer = dgv1.Rows(row - 5).Cells(0).Value

        If CuPremiere = True Then
            If cRound >= 2 And cRound1 >= 2 Then
                MsgBox("gresit de 2 ori 2 randuri > 2 consecutive")
            End If
        End If
    End Sub
    'btnInapoi (IN TESTE)
    Private Sub btnInapoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInapoi.Click
        NextPlayerQueue.Enqueue(NextPlayerStack.Pop)
        CurrentPlayerQueue.Enqueue(CurrentPlayerStack.Pop)
        NextPlayer = NextPlayerStack.Peek
        CurrentPlayer = CurrentPlayerStack.Peek

        If BidRound Then
            Listbox1.Items.Add(CurrentPlayer & " InapoiBid ")
            Listbox1.Items.Add(NextPlayer & " InapoiBid ")
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            HighlightNextPlayer()
        End If
        If EndRound Then
            Listbox1.Items.Add(CurrentPlayer & " InapoiEnd ")
            Listbox1.Items.Add(NextPlayer & " InapoiEnd ")
            Listbox1.TopIndex = Listbox1.Items.Count - 1
            HighlightNextPlayer()
        End If

        ListboxMsg()
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub
#End Region

#Region "OLD CODE"
    '(OLD CODE ZONE)
    'Enter Player names and Color Picker 
    'Private Sub NamesAndColor()
    '    'If Statements for 4 Players
    '    If Radio4Players.Checked Then
    '        Panel5.Visible = True
    '        GroupBox1.Visible = True
    '        TotalPlayers = 4
    '        Listbox1.Items.Add("Adauga Numele Jucatorilor!")
    '        Listbox1.Items.Add(".....................")
    '        Player5.Visible = False
    '        Player6.Visible = False
    '        BidP5.Visible = False
    '        EndP5.Visible = False
    '        BidP6.Visible = False
    '        EndP6.Visible = False
    '        Player1Name = InputBox("Nume Player1: ", "title")
    '        dgv1.Columns(1).HeaderText = Player1Name
    '        Listbox1.Items.Add("Nume Player1: " & Player1Name)
    '        'The Color Picker for Player1
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(1).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(2).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(3).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player2Name = InputBox("Nume Player2: ", "title")
    '        dgv1.Columns(4).HeaderText = Player2Name
    '        Listbox1.Items.Add("Nume Player2: " & Player2Name)
    '        'The Color Picker for Player2
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(4).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(5).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(6).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player3Name = InputBox("Nume Player3: ", "title")
    '        dgv1.Columns(7).HeaderText = Player3Name
    '        Listbox1.Items.Add("Nume Player3: " & Player3Name)
    '        'The Color Picker for Player3
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(7).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(8).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(9).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player4Name = InputBox("Nume Player4: ", "title")
    '        dgv1.Columns(10).HeaderText = Player4Name
    '        Listbox1.Items.Add("Nume Player4: " & Player4Name)
    '        Listbox1.Items.Add(".....................")
    '        'The Color Picker for Player4
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(10).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(11).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(12).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '    End If
    '    'If Statements for 5 Players
    '    If Radio5Players.Checked Then
    '        Panel5.Visible = True
    '        GroupBox1.Visible = True
    '        TotalPlayers = 5
    '        Listbox1.Items.Add("Adauga Numele Jucatorilor!")
    '        Player6.Visible = False
    '        BidP6.Visible = False
    '        EndP6.Visible = False
    '        Player1Name = InputBox("Nume Player1:  ", "title")
    '        dgv1.Columns(1).HeaderText = Player1Name
    '        Listbox1.Items.Add("Nume Player1: " & Player1Name)
    '        'The Color Picker for Player1
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(1).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(2).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(3).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player2Name = InputBox("Nume Player2:  ", "title")
    '        dgv1.Columns(4).HeaderText = Player2Name
    '        Listbox1.Items.Add("Nume Player2: " & Player2Name)
    '        'The Color Picker for Player2
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(4).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(5).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(6).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player3Name = InputBox("Nume Player3:  ", "title")
    '        dgv1.Columns(7).HeaderText = Player3Name
    '        Listbox1.Items.Add("Nume Player3: " & Player3Name)
    '        'The Color Picker for Player3
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(7).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(8).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(9).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player4Name = InputBox("Nume Player4:  ", "title")
    '        dgv1.Columns(10).HeaderText = Player4Name
    '        Listbox1.Items.Add("Nume Player4: " & Player4Name)
    '        'The Color Picker for Player4
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(10).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(11).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(12).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player5Name = InputBox("Nume Player5:  ", "title")
    '        dgv1.Columns(13).HeaderText = Player5Name
    '        Listbox1.Items.Add("Nume Player5: " & Player5Name)
    '        Listbox1.Items.Add(".....................")
    '        'The Color Picker for Player5
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(13).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(14).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(15).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '    End If
    '    'If Statements for 6 Players
    '    If Radio6Players.Checked Then
    '        Panel5.Visible = True
    '        GroupBox1.Visible = True
    '        TotalPlayers = 6
    '        Listbox1.Items.Add("Adauga Numele Jucatorilor!")
    '        Player1Name = InputBox("Nume Player1: ", "title")
    '        dgv1.Columns(1).HeaderText = Player1Name
    '        Listbox1.Items.Add("Nume Player1: " & Player1Name)
    '        'The Color Picker for Player1
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(1).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(2).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(3).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player2Name = InputBox("Nume Player2: ", "title")
    '        dgv1.Columns(4).HeaderText = Player2Name
    '        Listbox1.Items.Add("Nume Player2: " & Player2Name)
    '        'The Color Picker for Player2
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(4).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(5).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(6).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player3Name = InputBox("Nume Player3: ", "title")
    '        dgv1.Columns(7).HeaderText = Player3Name
    '        Listbox1.Items.Add("Nume Player3: " & Player3Name)
    '        'The Color Picker for Player3
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(7).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(8).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(9).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player4Name = InputBox("Nume Player4: ", "title")
    '        dgv1.Columns(10).HeaderText = Player4Name
    '        Listbox1.Items.Add("Nume Player4: " & Player4Name)
    '        'The Color Picker for Player4
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(10).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(11).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(12).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player5Name = InputBox("Nume Player5: ", "title")
    '        dgv1.Columns(13).HeaderText = Player5Name
    '        Listbox1.Items.Add("Nume Player5: " & Player5Name)
    '        'The Color Picker for Player5
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(13).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(14).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(15).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '        Player6Name = InputBox("Nume Player6: ", "title")
    '        dgv1.Columns(16).HeaderText = Player6Name
    '        Listbox1.Items.Add("Nume Player6: " & Player6Name)
    '        Listbox1.Items.Add(".....................")
    '        'The Color Picker for Player6
    '        'If (ColorPicker.ShowDialog() = DialogResult.OK) Then
    '        '    Me.dgv1.Columns(16).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(17).DefaultCellStyle.BackColor = ColorPicker.Color
    '        '    Me.dgv1.Columns(18).DefaultCellStyle.BackColor = ColorPicker.Color
    '        'End If
    '    End If
    'End Sub


    'btnUpdateScore
    'Private Sub btnUpdScore_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdScore.Click
    '    'Check if TotalEndBid matches cRound and if different display message
    '    If dgv1.Rows(row).Cells(20).Value = cRound Then
    '        'Loop Current and Next Player
    '        CurrentPlayerQueue.Dequeue()
    '        NextPlayerQueue.Dequeue()
    '        DealerQueue.Dequeue()
    '    ElseIf dgv1.Rows(row).Cells(20).Value > cRound Then
    '        MsgBox("Ai adaugat prea multe! Rescrie Runda!")
    '        dgv1.Rows.Remove(dgv1.Rows(row))
    '        row -= 1
    '        cRoundIndex -= 1
    '    ElseIf dgv1.Rows(row).Cells(20).Value < cRound Then
    '        MsgBox("Ai adaugat prea putine! Rescrie Runda!")
    '        dgv1.Rows.Remove(dgv1.Rows(row))
    '        row -= 1
    '        cRoundIndex -= 1
    '    End If
    '    'Enable btnStartNextRound
    '    'Disable GroupBox1, btnEndRoundScore, btn UpdateScore
    '    btnStartNextRound.Enabled = True
    '    GroupBox1.Enabled = False
    '    btnEndRoundScore.Enabled = False
    '    btnUpdScore.Enabled = False
    '    'Update Scores in DGV
    '    dgv1.Rows(row).Cells(1).Value = ScorP1()
    '    dgv1.Rows(row).Cells(4).Value = ScorP2()
    '    dgv1.Rows(row).Cells(7).Value = ScorP3()
    '    dgv1.Rows(row).Cells(10).Value = ScorP4()
    '    dgv1.Rows(row).Cells(13).Value = ScorP5()
    '    dgv1.Rows(row).Cells(16).Value = ScorP6()
    '    'System Window Message to announce Scores Round
    '    Listbox1.Items.Add("+++ Scorul Runda " & row & " +++")
    '    Listbox1.Items.Add(".....................")
    '    Listbox1.TopIndex = Listbox1.Items.Count - 1
    '    'Increase row Value to go to Next DGV row
    '    row += 1
    '    'Highlight Dealer
    '    HighlightDealer()
    '    WinCondition()
    'End Sub

    'Public Sub UpdateScore()
    '    'Check if TotalEndBid matches cRound and if different display message
    '    If dgv1.Rows(row).Cells(20).Value = cRound Then
    '        'Loop Current and Next Player
    '        CurrentPlayerQueue.Dequeue()
    '        NextPlayerQueue.Dequeue()
    '        DealerQueue.Dequeue()
    '    ElseIf dgv1.Rows(row).Cells(20).Value > cRound Then
    '        MsgBox("Ai adaugat prea multe! Rescrie Runda!")
    '        dgv1.Rows.Remove(dgv1.Rows(row))
    '        row -= 1
    '        cRoundIndex -= 1
    '    ElseIf dgv1.Rows(row).Cells(20).Value < cRound Then
    '        MsgBox("Ai adaugat prea putine! Rescrie Runda!")
    '        dgv1.Rows.Remove(dgv1.Rows(row))
    '        row -= 1
    '        cRoundIndex -= 1
    '    End If
    '    'Enable btnStartNextRound
    '    'Disable GroupBox1, btnEndRoundScore, btn UpdateScore
    '    btnStartNextRound.Enabled = True
    '    GroupBox1.Enabled = False
    '    btnEndRoundScore.Enabled = False
    '    btnUpdScore.Enabled = False
    '    'Update Scores in DGV
    '    dgv1.Rows(row).Cells(1).Value = ScorP1()
    '    dgv1.Rows(row).Cells(4).Value = ScorP2()
    '    dgv1.Rows(row).Cells(7).Value = ScorP3()
    '    dgv1.Rows(row).Cells(10).Value = ScorP4()
    '    dgv1.Rows(row).Cells(13).Value = ScorP5()
    '    dgv1.Rows(row).Cells(16).Value = ScorP6()
    '    'System Window Message to announce Scores Round
    '    Listbox1.Items.Add("+++ Scorul Runda " & row & " +++")
    '    Listbox1.Items.Add(".....................")
    '    Listbox1.TopIndex = Listbox1.Items.Count - 1
    '    'Increase row Value to go to Next DGV row
    '    row += 1
    '    'Highlight Dealer
    '    HighlightDealer()
    '    WinCondition()
    'End Sub
    'Menu_Minimize
#End Region

End Class