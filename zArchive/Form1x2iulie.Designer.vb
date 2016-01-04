<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Round = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Player1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Player2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Player3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Player4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Player5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP5 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Player6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BidP6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.E1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.E6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTotalPlayers = New System.Windows.Forms.Label()
        Me.btnAddScore = New System.Windows.Forms.ListBox()
        Me.lblJocDe = New System.Windows.Forms.Label()
        Me.btnP1 = New System.Windows.Forms.Button()
        Me.btnP2 = New System.Windows.Forms.Button()
        Me.btnP3 = New System.Windows.Forms.Button()
        Me.btnP4 = New System.Windows.Forms.Button()
        Me.btnP5 = New System.Windows.Forms.Button()
        Me.btnP6 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnEndRoundScore = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.End8 = New System.Windows.Forms.Button()
        Me.End7 = New System.Windows.Forms.Button()
        Me.End6 = New System.Windows.Forms.Button()
        Me.End5 = New System.Windows.Forms.Button()
        Me.End4 = New System.Windows.Forms.Button()
        Me.End3 = New System.Windows.Forms.Button()
        Me.End2 = New System.Windows.Forms.Button()
        Me.End1 = New System.Windows.Forms.Button()
        Me.EndP5 = New System.Windows.Forms.Button()
        Me.EndP3 = New System.Windows.Forms.Button()
        Me.EndP6 = New System.Windows.Forms.Button()
        Me.End0 = New System.Windows.Forms.Button()
        Me.EndP4 = New System.Windows.Forms.Button()
        Me.EndP2 = New System.Windows.Forms.Button()
        Me.EndP1 = New System.Windows.Forms.Button()
        Me.btnStartNextRound = New System.Windows.Forms.Button()
        Me.btnUpdScore = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Round, Me.Player1, Me.BidP1, Me.Player2, Me.BidP2, Me.Player3, Me.BidP3, Me.Player4, Me.BidP4, Me.Player5, Me.BidP5, Me.Player6, Me.BidP6, Me.E1, Me.E2, Me.E3, Me.E4, Me.E5, Me.E6})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 190)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1172, 490)
        Me.DataGridView1.TabIndex = 0
        '
        'Round
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Round.DefaultCellStyle = DataGridViewCellStyle1
        Me.Round.FillWeight = 300.0!
        Me.Round.Frozen = True
        Me.Round.HeaderText = "Round"
        Me.Round.Name = "Round"
        Me.Round.ReadOnly = True
        Me.Round.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Round.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Round.Width = 50
        '
        'Player1
        '
        Me.Player1.Frozen = True
        Me.Player1.HeaderText = "Player1"
        Me.Player1.Name = "Player1"
        Me.Player1.ReadOnly = True
        Me.Player1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP1
        '
        Me.BidP1.Frozen = True
        Me.BidP1.HeaderText = ""
        Me.BidP1.Name = "BidP1"
        Me.BidP1.ReadOnly = True
        Me.BidP1.Width = 40
        '
        'Player2
        '
        Me.Player2.Frozen = True
        Me.Player2.HeaderText = "Player2"
        Me.Player2.Name = "Player2"
        Me.Player2.ReadOnly = True
        Me.Player2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP2
        '
        Me.BidP2.Frozen = True
        Me.BidP2.HeaderText = ""
        Me.BidP2.Name = "BidP2"
        Me.BidP2.ReadOnly = True
        Me.BidP2.Width = 40
        '
        'Player3
        '
        Me.Player3.Frozen = True
        Me.Player3.HeaderText = "Player3"
        Me.Player3.Name = "Player3"
        Me.Player3.ReadOnly = True
        Me.Player3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP3
        '
        Me.BidP3.Frozen = True
        Me.BidP3.HeaderText = ""
        Me.BidP3.Name = "BidP3"
        Me.BidP3.ReadOnly = True
        Me.BidP3.Width = 40
        '
        'Player4
        '
        Me.Player4.Frozen = True
        Me.Player4.HeaderText = "Player4"
        Me.Player4.Name = "Player4"
        Me.Player4.ReadOnly = True
        Me.Player4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP4
        '
        Me.BidP4.Frozen = True
        Me.BidP4.HeaderText = ""
        Me.BidP4.Name = "BidP4"
        Me.BidP4.ReadOnly = True
        Me.BidP4.Width = 40
        '
        'Player5
        '
        Me.Player5.Frozen = True
        Me.Player5.HeaderText = "Player5"
        Me.Player5.Name = "Player5"
        Me.Player5.ReadOnly = True
        Me.Player5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP5
        '
        Me.BidP5.Frozen = True
        Me.BidP5.HeaderText = ""
        Me.BidP5.Name = "BidP5"
        Me.BidP5.ReadOnly = True
        Me.BidP5.Width = 40
        '
        'Player6
        '
        Me.Player6.Frozen = True
        Me.Player6.HeaderText = "Player6"
        Me.Player6.Name = "Player6"
        Me.Player6.ReadOnly = True
        Me.Player6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BidP6
        '
        Me.BidP6.Frozen = True
        Me.BidP6.HeaderText = ""
        Me.BidP6.Name = "BidP6"
        Me.BidP6.ReadOnly = True
        Me.BidP6.Width = 40
        '
        'E1
        '
        Me.E1.Frozen = True
        Me.E1.HeaderText = "E1"
        Me.E1.Name = "E1"
        Me.E1.Width = 40
        '
        'E2
        '
        Me.E2.Frozen = True
        Me.E2.HeaderText = "E2"
        Me.E2.Name = "E2"
        Me.E2.Width = 40
        '
        'E3
        '
        Me.E3.Frozen = True
        Me.E3.HeaderText = "E3"
        Me.E3.Name = "E3"
        Me.E3.Width = 40
        '
        'E4
        '
        Me.E4.Frozen = True
        Me.E4.HeaderText = "E4"
        Me.E4.Name = "E4"
        Me.E4.Width = 40
        '
        'E5
        '
        Me.E5.Frozen = True
        Me.E5.HeaderText = "E5"
        Me.E5.Name = "E5"
        Me.E5.Width = 40
        '
        'E6
        '
        Me.E6.Frozen = True
        Me.E6.HeaderText = "E6"
        Me.E6.Name = "E6"
        Me.E6.Width = 40
        '
        'lblTotalPlayers
        '
        Me.lblTotalPlayers.AutoSize = True
        Me.lblTotalPlayers.Location = New System.Drawing.Point(758, 9)
        Me.lblTotalPlayers.Name = "lblTotalPlayers"
        Me.lblTotalPlayers.Size = New System.Drawing.Size(74, 13)
        Me.lblTotalPlayers.TabIndex = 3
        Me.lblTotalPlayers.Text = "Total Players: "
        '
        'btnAddScore
        '
        Me.btnAddScore.FormattingEnabled = True
        Me.btnAddScore.Location = New System.Drawing.Point(761, 25)
        Me.btnAddScore.Name = "btnAddScore"
        Me.btnAddScore.Size = New System.Drawing.Size(186, 147)
        Me.btnAddScore.TabIndex = 7
        '
        'lblJocDe
        '
        Me.lblJocDe.AutoSize = True
        Me.lblJocDe.Location = New System.Drawing.Point(775, 642)
        Me.lblJocDe.Name = "lblJocDe"
        Me.lblJocDe.Size = New System.Drawing.Size(0, 13)
        Me.lblJocDe.TabIndex = 10
        '
        'btnP1
        '
        Me.btnP1.Location = New System.Drawing.Point(12, 50)
        Me.btnP1.Name = "btnP1"
        Me.btnP1.Size = New System.Drawing.Size(65, 23)
        Me.btnP1.TabIndex = 12
        Me.btnP1.Text = "Player1"
        Me.btnP1.UseVisualStyleBackColor = True
        '
        'btnP2
        '
        Me.btnP2.Location = New System.Drawing.Point(83, 50)
        Me.btnP2.Name = "btnP2"
        Me.btnP2.Size = New System.Drawing.Size(65, 23)
        Me.btnP2.TabIndex = 13
        Me.btnP2.Text = "Player2"
        Me.btnP2.UseVisualStyleBackColor = True
        '
        'btnP3
        '
        Me.btnP3.Location = New System.Drawing.Point(154, 49)
        Me.btnP3.Name = "btnP3"
        Me.btnP3.Size = New System.Drawing.Size(65, 23)
        Me.btnP3.TabIndex = 14
        Me.btnP3.Text = "Player3"
        Me.btnP3.UseVisualStyleBackColor = True
        '
        'btnP4
        '
        Me.btnP4.Location = New System.Drawing.Point(12, 79)
        Me.btnP4.Name = "btnP4"
        Me.btnP4.Size = New System.Drawing.Size(65, 23)
        Me.btnP4.TabIndex = 15
        Me.btnP4.Text = "Player4"
        Me.btnP4.UseVisualStyleBackColor = True
        '
        'btnP5
        '
        Me.btnP5.Location = New System.Drawing.Point(83, 79)
        Me.btnP5.Name = "btnP5"
        Me.btnP5.Size = New System.Drawing.Size(65, 23)
        Me.btnP5.TabIndex = 16
        Me.btnP5.Text = "Player5"
        Me.btnP5.UseVisualStyleBackColor = True
        '
        'btnP6
        '
        Me.btnP6.Location = New System.Drawing.Point(154, 79)
        Me.btnP6.Name = "btnP6"
        Me.btnP6.Size = New System.Drawing.Size(65, 23)
        Me.btnP6.TabIndex = 17
        Me.btnP6.Text = "Player6"
        Me.btnP6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn8)
        Me.GroupBox1.Controls.Add(Me.btn7)
        Me.GroupBox1.Controls.Add(Me.btn6)
        Me.GroupBox1.Controls.Add(Me.btn5)
        Me.GroupBox1.Controls.Add(Me.btn4)
        Me.GroupBox1.Controls.Add(Me.btn3)
        Me.GroupBox1.Controls.Add(Me.btn2)
        Me.GroupBox1.Controls.Add(Me.btn1)
        Me.GroupBox1.Controls.Add(Me.btnP3)
        Me.GroupBox1.Controls.Add(Me.btnP6)
        Me.GroupBox1.Controls.Add(Me.btn0)
        Me.GroupBox1.Controls.Add(Me.btnP5)
        Me.GroupBox1.Controls.Add(Me.btnP4)
        Me.GroupBox1.Controls.Add(Me.btnP2)
        Me.GroupBox1.Controls.Add(Me.btnP1)
        Me.GroupBox1.Location = New System.Drawing.Point(72, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 108)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Bid"
        '
        'btn8
        '
        Me.btn8.Location = New System.Drawing.Point(178, 19)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(19, 24)
        Me.btn8.TabIndex = 29
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Location = New System.Drawing.Point(158, 19)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(19, 24)
        Me.btn7.TabIndex = 28
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Location = New System.Drawing.Point(137, 19)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(19, 24)
        Me.btn6.TabIndex = 27
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Location = New System.Drawing.Point(116, 19)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(19, 24)
        Me.btn5.TabIndex = 26
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Location = New System.Drawing.Point(95, 19)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(19, 24)
        Me.btn4.TabIndex = 25
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(74, 19)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(19, 24)
        Me.btn3.TabIndex = 24
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(54, 19)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(19, 24)
        Me.btn2.TabIndex = 23
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(33, 19)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(19, 24)
        Me.btn1.TabIndex = 22
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.Location = New System.Drawing.Point(12, 19)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(19, 24)
        Me.btn0.TabIndex = 21
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btnEndRoundScore
        '
        Me.btnEndRoundScore.Location = New System.Drawing.Point(335, 74)
        Me.btnEndRoundScore.Name = "btnEndRoundScore"
        Me.btnEndRoundScore.Size = New System.Drawing.Size(140, 23)
        Me.btnEndRoundScore.TabIndex = 22
        Me.btnEndRoundScore.Text = "End Round Bid --->"
        Me.btnEndRoundScore.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.End8)
        Me.GroupBox2.Controls.Add(Me.End7)
        Me.GroupBox2.Controls.Add(Me.End6)
        Me.GroupBox2.Controls.Add(Me.End5)
        Me.GroupBox2.Controls.Add(Me.End4)
        Me.GroupBox2.Controls.Add(Me.End3)
        Me.GroupBox2.Controls.Add(Me.End2)
        Me.GroupBox2.Controls.Add(Me.End1)
        Me.GroupBox2.Controls.Add(Me.EndP5)
        Me.GroupBox2.Controls.Add(Me.EndP3)
        Me.GroupBox2.Controls.Add(Me.EndP6)
        Me.GroupBox2.Controls.Add(Me.End0)
        Me.GroupBox2.Controls.Add(Me.EndP4)
        Me.GroupBox2.Controls.Add(Me.EndP2)
        Me.GroupBox2.Controls.Add(Me.EndP1)
        Me.GroupBox2.Location = New System.Drawing.Point(504, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 108)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Bid"
        '
        'End8
        '
        Me.End8.Location = New System.Drawing.Point(178, 19)
        Me.End8.Name = "End8"
        Me.End8.Size = New System.Drawing.Size(19, 24)
        Me.End8.TabIndex = 29
        Me.End8.Text = "8"
        Me.End8.UseVisualStyleBackColor = True
        '
        'End7
        '
        Me.End7.Location = New System.Drawing.Point(158, 19)
        Me.End7.Name = "End7"
        Me.End7.Size = New System.Drawing.Size(19, 24)
        Me.End7.TabIndex = 28
        Me.End7.Text = "7"
        Me.End7.UseVisualStyleBackColor = True
        '
        'End6
        '
        Me.End6.Location = New System.Drawing.Point(137, 19)
        Me.End6.Name = "End6"
        Me.End6.Size = New System.Drawing.Size(19, 24)
        Me.End6.TabIndex = 27
        Me.End6.Text = "6"
        Me.End6.UseVisualStyleBackColor = True
        '
        'End5
        '
        Me.End5.Location = New System.Drawing.Point(116, 19)
        Me.End5.Name = "End5"
        Me.End5.Size = New System.Drawing.Size(19, 24)
        Me.End5.TabIndex = 26
        Me.End5.Text = "5"
        Me.End5.UseVisualStyleBackColor = True
        '
        'End4
        '
        Me.End4.Location = New System.Drawing.Point(95, 19)
        Me.End4.Name = "End4"
        Me.End4.Size = New System.Drawing.Size(19, 24)
        Me.End4.TabIndex = 25
        Me.End4.Text = "4"
        Me.End4.UseVisualStyleBackColor = True
        '
        'End3
        '
        Me.End3.Location = New System.Drawing.Point(74, 19)
        Me.End3.Name = "End3"
        Me.End3.Size = New System.Drawing.Size(19, 24)
        Me.End3.TabIndex = 24
        Me.End3.Text = "3"
        Me.End3.UseVisualStyleBackColor = True
        '
        'End2
        '
        Me.End2.Location = New System.Drawing.Point(54, 19)
        Me.End2.Name = "End2"
        Me.End2.Size = New System.Drawing.Size(19, 24)
        Me.End2.TabIndex = 23
        Me.End2.Text = "2"
        Me.End2.UseVisualStyleBackColor = True
        '
        'End1
        '
        Me.End1.Location = New System.Drawing.Point(33, 19)
        Me.End1.Name = "End1"
        Me.End1.Size = New System.Drawing.Size(19, 24)
        Me.End1.TabIndex = 22
        Me.End1.Text = "1"
        Me.End1.UseVisualStyleBackColor = True
        '
        'EndP5
        '
        Me.EndP5.Location = New System.Drawing.Point(83, 79)
        Me.EndP5.Name = "EndP5"
        Me.EndP5.Size = New System.Drawing.Size(65, 23)
        Me.EndP5.TabIndex = 16
        Me.EndP5.Text = "Player5"
        Me.EndP5.UseVisualStyleBackColor = True
        '
        'EndP3
        '
        Me.EndP3.Location = New System.Drawing.Point(154, 49)
        Me.EndP3.Name = "EndP3"
        Me.EndP3.Size = New System.Drawing.Size(65, 23)
        Me.EndP3.TabIndex = 14
        Me.EndP3.Text = "Player3"
        Me.EndP3.UseVisualStyleBackColor = True
        '
        'EndP6
        '
        Me.EndP6.Location = New System.Drawing.Point(154, 79)
        Me.EndP6.Name = "EndP6"
        Me.EndP6.Size = New System.Drawing.Size(65, 23)
        Me.EndP6.TabIndex = 17
        Me.EndP6.Text = "Player6"
        Me.EndP6.UseVisualStyleBackColor = True
        '
        'End0
        '
        Me.End0.Location = New System.Drawing.Point(12, 19)
        Me.End0.Name = "End0"
        Me.End0.Size = New System.Drawing.Size(19, 24)
        Me.End0.TabIndex = 21
        Me.End0.Text = "0"
        Me.End0.UseVisualStyleBackColor = True
        '
        'EndP4
        '
        Me.EndP4.Location = New System.Drawing.Point(12, 79)
        Me.EndP4.Name = "EndP4"
        Me.EndP4.Size = New System.Drawing.Size(65, 23)
        Me.EndP4.TabIndex = 15
        Me.EndP4.Text = "Player4"
        Me.EndP4.UseVisualStyleBackColor = True
        '
        'EndP2
        '
        Me.EndP2.Location = New System.Drawing.Point(83, 50)
        Me.EndP2.Name = "EndP2"
        Me.EndP2.Size = New System.Drawing.Size(65, 23)
        Me.EndP2.TabIndex = 13
        Me.EndP2.Text = "Player2"
        Me.EndP2.UseVisualStyleBackColor = True
        '
        'EndP1
        '
        Me.EndP1.Location = New System.Drawing.Point(12, 50)
        Me.EndP1.Name = "EndP1"
        Me.EndP1.Size = New System.Drawing.Size(65, 23)
        Me.EndP1.TabIndex = 12
        Me.EndP1.Text = "Player1"
        Me.EndP1.UseVisualStyleBackColor = True
        '
        'btnStartNextRound
        '
        Me.btnStartNextRound.Location = New System.Drawing.Point(335, 44)
        Me.btnStartNextRound.Name = "btnStartNextRound"
        Me.btnStartNextRound.Size = New System.Drawing.Size(140, 23)
        Me.btnStartNextRound.TabIndex = 31
        Me.btnStartNextRound.Text = "< --- Start Next Round"
        Me.btnStartNextRound.UseVisualStyleBackColor = True
        '
        'btnUpdScore
        '
        Me.btnUpdScore.Location = New System.Drawing.Point(335, 103)
        Me.btnUpdScore.Name = "btnUpdScore"
        Me.btnUpdScore.Size = New System.Drawing.Size(140, 23)
        Me.btnUpdScore.TabIndex = 32
        Me.btnUpdScore.Text = "Update Score"
        Me.btnUpdScore.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 692)
        Me.Controls.Add(Me.btnUpdScore)
        Me.Controls.Add(Me.btnStartNextRound)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnEndRoundScore)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblJocDe)
        Me.Controls.Add(Me.btnAddScore)
        Me.Controls.Add(Me.lblTotalPlayers)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalPlayers As System.Windows.Forms.Label
    Friend WithEvents btnAddScore As System.Windows.Forms.ListBox
    Friend WithEvents lblJocDe As System.Windows.Forms.Label
    Friend WithEvents btnP1 As System.Windows.Forms.Button
    Friend WithEvents btnP2 As System.Windows.Forms.Button
    Friend WithEvents btnP3 As System.Windows.Forms.Button
    Friend WithEvents btnP4 As System.Windows.Forms.Button
    Friend WithEvents btnP5 As System.Windows.Forms.Button
    Friend WithEvents btnP6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEndRoundScore As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents End8 As System.Windows.Forms.Button
    Friend WithEvents End7 As System.Windows.Forms.Button
    Friend WithEvents End6 As System.Windows.Forms.Button
    Friend WithEvents End5 As System.Windows.Forms.Button
    Friend WithEvents End4 As System.Windows.Forms.Button
    Friend WithEvents End3 As System.Windows.Forms.Button
    Friend WithEvents End2 As System.Windows.Forms.Button
    Friend WithEvents End1 As System.Windows.Forms.Button
    Friend WithEvents EndP6 As System.Windows.Forms.Button
    Friend WithEvents End0 As System.Windows.Forms.Button
    Friend WithEvents EndP5 As System.Windows.Forms.Button
    Friend WithEvents EndP4 As System.Windows.Forms.Button
    Friend WithEvents EndP3 As System.Windows.Forms.Button
    Friend WithEvents EndP2 As System.Windows.Forms.Button
    Friend WithEvents EndP1 As System.Windows.Forms.Button
    Friend WithEvents btnStartNextRound As System.Windows.Forms.Button
    Friend WithEvents Round As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Player1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Player2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Player3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Player4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP4 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Player5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP5 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Player6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BidP6 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents E1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUpdScore As System.Windows.Forms.Button

End Class
