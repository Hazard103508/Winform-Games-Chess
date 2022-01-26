using Chess.Elements;
using Game;
using Game.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    /// <summary>
    /// Formulario que contiene la logica del juego de Ajedrez
    /// </summary>
    public partial class Demo : Game.Game
    {
        #region Constructor
        public Demo() : base()
        {
            InitializeComponent();

            Initialize();
            Start_Match();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Recursos de imagenes a usar en el juego
        /// </summary>
        public Resources Resources { get; set; }
        /// <summary>
        /// Tablero de juego
        /// </summary>
        private Board Board { get; set; }
        /// <summary>
        /// Lista de piezas de ajedrez
        /// </summary>
        private List<Piece_Base> Pieces { get; set; }
        /// <summary>
        /// Informacion del juegador 1
        /// </summary>
        public Player Player1 { get; set; }
        /// <summary>
        ///  Informacion del juegador 2
        /// </summary>
        public Player Player2 { get; set; }
        /// <summary>
        /// Jugador que tiene el turno actual
        /// </summary>
        public Player CurrentPlayer { get; set; }
        /// <summary>
        /// Registro de las acciones realizadas en el utlimo turno
        /// </summary>
        public List<ActionLog> ActionLog { get; set; }
        /// <summary>
        /// Estado del juego
        /// </summary>
        public State GameState { get; set; }
        #endregion

        #region Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start_Match();
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            var lastAction = this.ActionLog.LastOrDefault();
            if (lastAction != null)
            {
                lastAction.Moves.ForEach(m => m.Piece.Location = m.Original_Location);
                lastAction.Removed_Pieces.ForEach(x => this.Pieces.Add(x));

                if (lastAction.Added_Piece != null)
                    this.Pieces.Remove(lastAction.Added_Piece);

                this.ActionLog.Remove(lastAction);
                Next_Turn(false);
                Board.Clear_EnabledMoves();
                this.Pieces.ForEach(p => p.Selected = false);
            }
        }
        private void Demo_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            Point _mouseLocation = new Point(e.Location.X - 5, e.Location.Y - 5); // resto los bordes del tablero
            var cell_Location = new Point(e.Location.X / 105, e.Location.Y / 105); // cada celda tiene un tamaños de  100x100 + 5x5 de borde
            // Obtengo la coordenada del tablero donde se realizo click

            if (!Move_Piece(cell_Location)) // si existe una pieza seleccionada, intenta moverla a la celda donde se realizo click
                Set_SelectedPiece(cell_Location); // si la pieza seleccionada no se puede mover a la celda destino, se intenta seleccionar otra pieza
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            base.Open_ZeroSoft_URL();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inicializa el juego cargando los recursos
        /// </summary>
        private void Initialize()
        {
            string directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
            this.Resources = new Resources()
            {
                Image_BoardTiles = Load_Image($"{directory}/Board.png"),
                Image_MoveTiles = Load_Image($"{directory}/TileMove.png"),
                Image_SelectedTile = Load_Image($"{directory}/TileSelected.png"),
                Image_WhitePawn = Load_Image($"{directory}/White_Pawn.png"),
                Image_White_Rook = Load_Image($"{directory}/White_Rook.png"),
                Image_White_Knight = Load_Image($"{directory}/White_Knight.png"),
                Image_White_Bishop = Load_Image($"{directory}/White_Bishop.png"),
                Image_White_Queen = Load_Image($"{directory}/White_Queen.png"),
                Image_White_King = Load_Image($"{directory}/White_King.png"),
                Image_BlackPawn = Load_Image($"{directory}/Black_Pawn.png"),
                Image_Black_Rook = Load_Image($"{directory}/Black_Rook.png"),
                Image_Black_Knight = Load_Image($"{directory}/Black_Knight.png"),
                Image_Black_Bishop = Load_Image($"{directory}/Black_Bishop.png"),
                Image_Black_Queen = Load_Image($"{directory}/Black_Queen.png"),
                Image_Black_King = Load_Image($"{directory}/Black_King.png")
            };
        }
        /// <summary>
        /// Inicia una nueva partida 
        /// </summary>
        private void Start_Match()
        {
            this.ActionLog = new List<ActionLog>();
            this.Pieces = new List<Piece_Base>();
            this.Board = new Board(this.Resources.Image_BoardTiles, this.Resources.Image_MoveTiles);
            this.GameState = State.Normal;

            //Blancas
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Pawn(this.Resources.Image_WhitePawn, Piece_Color.White));
            Add_Piece(new Piece_Rook(this.Resources.Image_White_Rook, Piece_Color.White));
            Add_Piece(new Piece_Knight(this.Resources.Image_White_Knight, Piece_Color.White));
            Add_Piece(new Piece_Bishop(this.Resources.Image_White_Bishop, Piece_Color.White));
            Add_Piece(new Piece_Queen(this.Resources.Image_White_Queen, Piece_Color.White));
            Add_Piece(new Piece_King(this.Resources.Image_White_King, Piece_Color.White));
            Add_Piece(new Piece_Bishop(this.Resources.Image_White_Bishop, Piece_Color.White));
            Add_Piece(new Piece_Knight(this.Resources.Image_White_Knight, Piece_Color.White));
            Add_Piece(new Piece_Rook(this.Resources.Image_White_Rook, Piece_Color.White));
            //Negras
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Pawn(this.Resources.Image_BlackPawn, Piece_Color.Black));
            Add_Piece(new Piece_Rook(this.Resources.Image_Black_Rook, Piece_Color.Black));
            Add_Piece(new Piece_Knight(this.Resources.Image_Black_Knight, Piece_Color.Black));
            Add_Piece(new Piece_Bishop(this.Resources.Image_Black_Bishop, Piece_Color.Black));
            Add_Piece(new Piece_King(this.Resources.Image_Black_King, Piece_Color.Black));
            Add_Piece(new Piece_Queen(this.Resources.Image_Black_Queen, Piece_Color.Black));
            Add_Piece(new Piece_Bishop(this.Resources.Image_Black_Bishop, Piece_Color.Black));
            Add_Piece(new Piece_Knight(this.Resources.Image_Black_Knight, Piece_Color.Black));
            Add_Piece(new Piece_Rook(this.Resources.Image_Black_Rook, Piece_Color.Black));

            Player1 = new Player(rbBlack.Checked ? Piece_Color.Black : Piece_Color.White, Player_Type.Human, 1);
            Player2 = new Player(rbBlack.Checked ? Piece_Color.White : Piece_Color.Black, Player_Type.Human, 2);
            CurrentPlayer = Player1.Color == Piece_Color.White ? Player1 : Player2; // inicia la partida el jugador que use las fichas blancas

            // Asigna las coordenadas de las piezas del juegar 1
            var lstPiecesPlayer1 = this.Pieces.Where(x => x.Color == Player1.Color).ToList();
            lstPiecesPlayer1[0].Location = new Point(0, 6);
            lstPiecesPlayer1[1].Location = new Point(1, 6);
            lstPiecesPlayer1[2].Location = new Point(2, 6);
            lstPiecesPlayer1[3].Location = new Point(3, 6);
            lstPiecesPlayer1[4].Location = new Point(4, 6);
            lstPiecesPlayer1[5].Location = new Point(5, 6);
            lstPiecesPlayer1[6].Location = new Point(6, 6);
            lstPiecesPlayer1[7].Location = new Point(7, 6);
            lstPiecesPlayer1[8].Location = new Point(0, 7);
            lstPiecesPlayer1[9].Location = new Point(1, 7);
            lstPiecesPlayer1[10].Location = new Point(2, 7);
            lstPiecesPlayer1[11].Location = new Point(3, 7);
            lstPiecesPlayer1[12].Location = new Point(4, 7);
            lstPiecesPlayer1[13].Location = new Point(5, 7);
            lstPiecesPlayer1[14].Location = new Point(6, 7);
            lstPiecesPlayer1[15].Location = new Point(7, 7);

            // Asigna las coordenadas de las piezas del juegar 2
            var lstPiecesPlayer2 = this.Pieces.Where(x => x.Color == Player2.Color).ToList();
            lstPiecesPlayer2[0].Location = new Point(7, 1);
            lstPiecesPlayer2[1].Location = new Point(6, 1);
            lstPiecesPlayer2[2].Location = new Point(5, 1);
            lstPiecesPlayer2[3].Location = new Point(4, 1);
            lstPiecesPlayer2[4].Location = new Point(3, 1);
            lstPiecesPlayer2[5].Location = new Point(2, 1);
            lstPiecesPlayer2[6].Location = new Point(1, 1);
            lstPiecesPlayer2[7].Location = new Point(0, 1);
            lstPiecesPlayer2[8].Location = new Point(7, 0);
            lstPiecesPlayer2[9].Location = new Point(6, 0);
            lstPiecesPlayer2[10].Location = new Point(5, 0);
            lstPiecesPlayer2[11].Location = new Point(4, 0);
            lstPiecesPlayer2[12].Location = new Point(3, 0);
            lstPiecesPlayer2[13].Location = new Point(2, 0);
            lstPiecesPlayer2[14].Location = new Point(1, 0);
            lstPiecesPlayer2[15].Location = new Point(0, 0);

            Next_Turn(true);
            base.Enabled = true;
        }
        /// <summary>
        /// Obtiene la posicion de pantalla que posee la pieza
        /// </summary>
        /// <param name="location">Coordenada dentro del tablero</param>
        /// <returns></returns>
        private Point Get_PiecePosition(Point location)
        {
            int _x = (location.X * 100) + 5 * (location.X + 1);
            int _y = (location.Y * 100) + 5 * (location.Y + 1);
            return new Point(_x, _y);
        }
        /// <summary>
        /// Agrega una pieza al tablero
        /// </summary>
        /// <param name="piece">Pieza a agregar</param>
        private void Add_Piece(Piece_Base piece, ActionLog log = null)
        {
            piece.SelectedImage = this.Resources.Image_SelectedTile; // asigna la imagen a mostrar en caso de ser seleccionada
            this.Pieces.Add(piece);  // Agrega la pieza a la lista de piezas en el tablero
            if (log != null)
                log.Added_Piece = piece;
        }
        /// <summary>
        /// Elimina una pieza del juego
        /// </summary>
        /// <param name="piece">Pieza a eliminar</param>
        /// <param name="log">Log de movimiento realizado</param>
        private void Remove_Piece(Piece_Base piece, ActionLog log)
        {
            this.Pieces.Remove(piece);  // Elimina la pieza de la lista de piezas del tablero
            log.Removed_Pieces.Add(piece);
        }
        /// <summary>
        /// Finaliza el turno actual
        /// </summary>
        /// <param name="firstTurn">Indica si es el primer turno</param>
        private void Next_Turn(bool firstTurn)
        {
            this.GameState = State.Normal;
            lblCheck.Text = string.Empty;
            lblMoves.Text = string.Empty;

            if (!firstTurn)
                CurrentPlayer = CurrentPlayer.Number == 1 ? Player2 : Player1;
            Set_MovesLocations(); // recalcula los movimientos habilitados para cada una de las piezas

            int moves = this.Pieces.Where(x => x.Color == CurrentPlayer.Color).Sum(x => x.EnabledMoves.Count());
            lblMoves.Text = moves.ToString();

            var king = this.Pieces.FirstOrDefault(x => x.Color == CurrentPlayer.Color && x.GetType() == typeof(Piece_King));
            var isCheck = this.Pieces.Any(x => x.Color != CurrentPlayer.Color && x.EnabledMoves.Contains(king.Location));
            // valida si en la juegada anterior se dejo al rey en jaque
            if (isCheck)
            {
                this.GameState = State.Check;
                if (moves == 0) // si nos quedamos sin movimientos es jaque mate
                    this.GameState = State.Checkmate;
            }
            else
            {
                if (moves == 0) // si nos quedamos sin movimientos y no es jaque, el juego queda en tabla
                    this.GameState = State.Draw;
            }

            lblCheck.Text = this.GameState.ToString();
            if (GameState == State.Checkmate || GameState == State.Draw)
            {
                MessageBox.Show(this.GameState.ToString(), "Chess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Selecciona una pieza del tablero
        /// </summary>
        /// <param name="cell_Location">Coordenadas de la celda seleccionada</param>
        private void Set_SelectedPiece(Point cell_Location)
        {
            Board.Clear_EnabledMoves();
            this.Pieces.ForEach(x => x.Selected = false); // deselecciono todas las fichas
            Piece_Base _selectedPiece = this.Pieces.FirstOrDefault(x => x.Location == cell_Location && x.Color == CurrentPlayer.Color);
            // busco una ficha para la coordenada donde se hizo click, solo si es del color correspondiente al jugador que tiene el turno

            if (_selectedPiece != null)
            {
                _selectedPiece.Selected = true; // se selecciona la ficha
                Array.ForEach(_selectedPiece.EnabledMoves, loc => Board.Cells[loc.X, loc.Y].CanMove = true); // colorea las celdas habilitadas 
            }
        }

        //METODOS QUE OBTIENEN LAS CELDAS HABILITADAS
        /// <summary>
        /// Obtiene
        /// </summary>
        private void Set_MovesLocations()
        {
            this.Pieces.ForEach(x => x.EnabledMoves = Get_MovesLocations(x, this.Pieces)); // movimientos habilitados que posee la pieza

            // valida los movimientos disponibles que puede realizar el juegador actual
            this.Pieces.Where(x => x.Color == CurrentPlayer.Color).ToList().ForEach(p =>
            {
                p.EnabledMoves = p.EnabledMoves.Where(loc => Valid_MovesLocations_Check(p, loc)).ToArray();
                // valida que el rey no quede en jaque al realizar el movimiento
            });
        }
        /// <summary>
        /// Obtiene las celdas a la cual puede desplazarce la pieza seleccionada
        /// </summary>
        /// <param name="piece">Pieza seleccionada</param>
        /// <param name="boardPieces">Lista de piezas que obstaculizan los movimientos de la la pieza seleccionada</param>
        private Point[] Get_MovesLocations(Piece_Base piece, List<Piece_Base> boardPieces)
        {
            List<Point> lstAvailableCell = new List<Point>();
            if (piece != null)
            {
                Array.ForEach(piece.Moves, x =>
                {
                    var displacement = x.Direction;
                    if (piece.Color == Player2.Color)
                    {
                        displacement = new Point(displacement.X * -1, displacement.Y * -1);
                        // si el turno es del jugado 2 invierto el desplazamiento para que las fichas bajen en vez de subir 
                    }

                    Point _location = piece.Location; // posicion inicial desde la cual se comienza a validar las celdas
                    while (true)
                    {
                        _location = new Point(_location.X + displacement.X, _location.Y + displacement.Y);
                        //posicion de celda a validar

                        if (_location.X > 7 || _location.Y > 7 || _location.X < 0 || _location.Y < 0)
                            break; // coordenada fuera del tablero "NO PERMITE MOVIMIENTO"

                        var _targetPiece = boardPieces.FirstOrDefault(y => y.Location == _location);

                        if (x.Type.HasFlag(Elements.Move_Type.Special)) // movimiento especial de pieza
                        {
                            if (!Get_MovesLocations_Special(piece, x, _targetPiece))
                                break; // "NO PERMITE MOVIMIENTO"
                        }
                        else
                        {
                            if (_targetPiece != null && _targetPiece.Color == piece.Color) // en la celda destino hay otra pieza
                                break; // la pieza destino es del mismo color que la pieza seleccionada "NO PERMITE MOVIMIENTO"
                        }

                        lstAvailableCell.Add(_location); // agrega la coordenada a la lista de celdas habilitadas "PERMITE MOVIMIENTO"

                        if (_targetPiece != null && _targetPiece.Color != piece.Color)
                            break; // no permite movimientos posteriores a la posicion de la pieza rival

                        if (!x.IsLinear) // si el movimiento de la ficha es lineal repite la operacion hasta encontrar una celda no habilitada
                            break;
                    }
                });
            }

            return lstAvailableCell.ToArray();
        }
        /// <summary>
        /// Valida si al realizar el movimiento de la pieza el rey queda en jaque
        /// </summary>
        /// <param name="piece">Pieza a desplazar</param>
        /// <param name="newLocation">Coordenada del tablero a validar</param>
        /// <returns></returns>
        private bool Valid_MovesLocations_Check(Piece_Base piece, Point newLocation)
        {
            Point _originalLocation = piece.Location; // posicion actual de la pieza
            piece.Location = newLocation; // asigna a la pieza la posicion nueva para analizar si el rey queda en jaque

            bool _result = true;

            var lstPieces = this.Pieces.Where(x =>
                x.Color != piece.Color &&
                x.Location != newLocation
            )
            .ToList();// obtiene las piezas rivales para analizar si alguna deja en jaque al rey

            if (lstPieces.Any()) // lista de piezas rival que atacan a la pieza seleccionada
            {
                var king = this.Pieces.First(x => x.Color == piece.Color && x.GetType() == typeof(Piece_King));

                // recalculo los movimientos habilitados de las piezas para determinar si alguna pone en jaque al rey
                var lstBoardPieces = this.Pieces.Where(x => !(x.Color != piece.Color && x.Location == newLocation)).ToList(); // obtiene todas las piezas del tabler ignorando la pieza que se asume fue eliminada al realizar el movimiento
                foreach (var p in lstPieces)
                {
                    var lstMoves = Get_MovesLocations(p, lstBoardPieces); //  obtiene las ubicaciones de desplazamiento de cada una de las piezas del rival
                    if (lstMoves.Any(x => x == king.Location))
                    {
                        _result = false; // si al menos una ficha rival queda al alcance del rey el movimiento se invalida
                        break;
                    }
                }
            }

            piece.Location = _originalLocation; // asigno la ubicacion original de la pieza
            return _result;
        }
        /// <summary>
        /// Obtiene las celdas a la cual puede desplazarce la pieza seleccionada utilizando un movimiento especial
        /// </summary>
        /// <param name="piece">Pieza a validar</param>
        /// <param name="move">Movimiento a validar</param>
        /// <param name="rivalPiece">Pieza rival que se encuentra en la coordenada destino</param>
        /// <returns></returns>
        private bool Get_MovesLocations_Special(Piece_Base piece, Piece_Move move, Piece_Base rivalPiece)
        {
            // CAMBIAR LOGICA
            // retornar tru en cada validacion

            if (piece.GetType() == typeof(Piece_Pawn))
            {
                #region Special Moves
                if (move.Direction.X == 0 && move.Direction.Y == -1) // desplazamiento frontal 1 casillero
                    return rivalPiece == null; // el casillero de en frente debe estar vacio

                if (move.Direction.X == 0 && move.Direction.Y == -2) // desplazamiento frontal 2 casillero, no permite atacar
                {
                    bool _condicion1 = rivalPiece == null; // la casilla destino debe estar vacia
                    bool _condicion2 = !this.Pieces.Any(p => p.Location.X == piece.Location.X && p.Location.Y == (CurrentPlayer.Number == 1 ? 5 : 2)); // la casilla frontal debe esta vacia
                    bool _condicion3 = (CurrentPlayer.Number == 1 && piece.Location.Y == 6) || (CurrentPlayer.Number == 2 && piece.Location.Y == 1); // debe ser el primer movimiento del peon

                    return _condicion1 && _condicion2 && _condicion3;
                }

                if ((move.Direction.X == -1 || move.Direction.X == 1) && move.Direction.Y == -1) // ataque a pieza rival en diagonal
                {
                    var lastAction = ActionLog.LastOrDefault();
                    if (rivalPiece == null && lastAction != null) // COMER AL PASO
                    {
                        var Last_Move = lastAction.Moves.Last();
                        // El peon rival debe estar en la misma fila que la pieza a mover, en una columna adyacente y debe haberce desplazado en el ultimo turno juegado 2 casilleros
                        if (CurrentPlayer.Number == 1 && piece.Location.Y == 3)  // el peon se desplaza hica arriba
                        {
                            var rival = this.Pieces.FirstOrDefault(p => p.Color != piece.Color && p.Location == new Point(piece.Location.X + move.Direction.X, piece.Location.Y));
                            if (rival != null && Last_Move.Piece.Equals(rival) && (Last_Move.New_Location.Y - Last_Move.Original_Location.Y) == 2)
                                return true; // Habilita comer al paso
                        }
                        if (CurrentPlayer.Number == 2 && piece.Location.Y == 4) // // el peon se desplaza hica abajo
                        {
                            var rival = this.Pieces.FirstOrDefault(p => p.Color != piece.Color && p.Location == new Point(piece.Location.X - move.Direction.X, piece.Location.Y));
                            if (rival != null && Last_Move.Piece.Equals(rival) && (Last_Move.New_Location.Y - Last_Move.Original_Location.Y) == -2)
                                return true; // Habilita comer al paso
                        }
                    }

                    if (rivalPiece != null && rivalPiece.Color != piece.Color)
                        return true; // el movimiento se habilita solo si hay un rival en la posiscion destino
                }
                #endregion
            }
            else if (piece.GetType() == typeof(Piece_King))
            {
                if (GameState != State.Normal) // el rey no puede estar en jaque
                    return false;

                //Enrrosque
                bool kingFirstMove = !ActionLog.Any(x => x.Moves.Any(y => y.Piece.Equals(piece))); // debe ser el primer mov. del rey
                if (!kingFirstMove)
                    return false;

                Point _moveDirection = CurrentPlayer.Number == 1 ? move.Direction : new Point(move.Direction.X * -1, move.Direction.Y * -1);
                Piece_Base _rock = null;
                if (_moveDirection.X < 0) // enrrosque largo
                    _rock = this.Pieces.FirstOrDefault(p => p.GetType() == typeof(Piece_Rook) && p.Location.X == 0 && p.Location.Y == piece.Location.Y);
                else // enrrosque corto
                    _rock = this.Pieces.FirstOrDefault(p => p.GetType() == typeof(Piece_Rook) && p.Location.X == 7 && p.Location.Y == piece.Location.Y);
                if (_rock == null) // si no existe la torre se asume que fue eliminada o movida de su casillero original
                    return false;

                bool rookFirstMove = !ActionLog.Any(x => x.Moves.Any(y => y.Piece.Equals(piece))); // debe ser el primer mov. de la torre
                if (!rookFirstMove) // debe ser el primer mov. de la torre
                    return false;

                int _moveX = _moveDirection.X < 0 ? -1 : 1;
                Point _location = new Point(piece.Location.X + _moveX, piece.Location.Y);
                while (_location != _rock.Location)
                {
                    bool _existPiece = this.Pieces.Any(p => p.Location == _location);
                    if (_existPiece)
                        return false; // no debe existir pieza entre el rey y la torre

                    bool _attackLoc = this.Pieces.Any(p => p.Color != piece.Color && p.EnabledMoves != null && p.EnabledMoves.Any(y => y == _location));
                    if (_attackLoc)
                        return false; // la ubicacion no puede estar bajo ataque de una pieza rival

                    _location = new Point(_location.X + _moveX, _location.Y);
                }

                return true; // el enroque es valido
            }

            return false;
        }

        //METODOS QUE DESPLAZAN LA FICHA SELECCIONADA
        /// <summary>
        /// Desplaza la pieza seleccionada a la celda indicada
        /// </summary>
        /// <param name="cell_Location">Coordenadas de la celda seleccionada</param>
        /// <returns></returns>
        private bool Move_Piece(Point cell_Location)
        {
            if (cell_Location.X > 7 || cell_Location.Y > 7 || cell_Location.X < 0 || cell_Location.Y < 0)
                return false; // coordenada fuera del tablero "NO PERMITE MOVIMIENTO"

            var selectedPiece = this.Pieces.FirstOrDefault(x => x.Selected);
            if (selectedPiece != null)
            {
                if (Board.Cells[cell_Location.X, cell_Location.Y].CanMove) // determina si la pieza seleccionada pueda moverse a la coordenada indicada
                {
                    var actionLog = new ActionLog();
                    actionLog.Moves.Add(new MoveLog
                    {
                        Piece = selectedPiece,
                        Original_Location = selectedPiece.Location,
                        New_Location = cell_Location
                    });
                    this.ActionLog.Add(actionLog);
                    // Registra el ultimo movimiento realizado para poder validar movimiento "Comer al Paso"

                    Move_Piece_Special(selectedPiece, cell_Location, actionLog);
                    // ejecuta un comportamiento especial si la jugada lo requiere

                    var targetPiece = this.Pieces.FirstOrDefault(x => x.Color != selectedPiece.Color && x.Location == cell_Location);
                    if (targetPiece != null)
                        Remove_Piece(targetPiece, actionLog); // elimina la pieza que se encuentre en la posicion destino

                    selectedPiece.Location = cell_Location; // mueve la pieza seleccionada a la coordenada destino
                    selectedPiece.Selected = false;
                    Board.Clear_EnabledMoves();

                    //Valid_Check(selectedPiece); // valida si hay jaque al rey contrincante tras el movimiento

                    Next_Turn(false); //Luego de mover la pieza comienza el turno del otro jugador
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Ejecuta un movimiento especial de una pieza
        /// </summary>
        /// <param name="piece">Pieza que realiza el movimiento</param>
        /// <param name="targetLocation">Coordenada del tablero a donde se dezplaza la pieza</param>
        /// <param name="log">Log de movimiento realizado</param>
        private void Move_Piece_Special(Piece_Base piece, Point targetLocation, ActionLog log)
        {
            if (piece.GetType() == typeof(Piece_Pawn))
            {
                #region Sprecial Move
                if (targetLocation.Y == (piece.Color == Player1.Color ? 0 : 7)) // el player uno corona la pieza en la fila superior y el player 2 en la fila inferior
                {
                    Piece_Base _newPiece = null;
                    if (CurrentPlayer.Type == Player_Type.Human)
                    {
                        while (_newPiece == null)
                        {
                            var form = new PieceSelector(this.Resources, piece.Color);
                            form.ShowDialog();
                            _newPiece = form.Selected_Piece;
                        }
                        _newPiece.Location = targetLocation;
                    }

                    Remove_Piece(piece, log); // Elimina el peon
                    Add_Piece(_newPiece, log); // agrega la nueva pieza
                }

                // si el peon se desplaza en diagonal a una celda vacia se asume que utilizo el movimiento especial "Comer al Paso"
                var displacement = new Point(targetLocation.X - piece.Location.X, targetLocation.Y - piece.Location.Y);
                if ((displacement.X == -1 || displacement.X == 1) && displacement.Y == (CurrentPlayer.Equals(Player1) ? -1 : 1) && !this.Pieces.Any(x => x.Location == targetLocation))
                {
                    Point rivalLocation = new Point(targetLocation.X, targetLocation.Y + (CurrentPlayer.Equals(Player1) ? 1 : -1));
                    var romovePiece = this.Pieces.First(p => p.Location == rivalLocation);
                    Remove_Piece(romovePiece, log); // elimina el peon rival
                }
                #endregion
            }
            if (piece.GetType() == typeof(Piece_King))
            {
                if (Math.Abs(piece.Location.X - targetLocation.X) == 2) // enroque
                {
                    Piece_Base _rock = null;
                    if ((targetLocation.X - piece.Location.X) < 0) // enrrosque largo
                        _rock = this.Pieces.FirstOrDefault(p => p.GetType() == typeof(Piece_Rook) && p.Location.X == 0 && p.Location.Y == piece.Location.Y);
                    else // enrrosque corto
                        _rock = this.Pieces.FirstOrDefault(p => p.GetType() == typeof(Piece_Rook) && p.Location.X == 7 && p.Location.Y == piece.Location.Y);

                    var _newRookLoc = _rock.Location.X == 7 ?
                        new Point(_rock.Location.X - 2, _rock.Location.Y) :
                        new Point(_rock.Location.X + 3, _rock.Location.Y);

                    log.Moves.Add(new MoveLog()
                    {
                        Piece = _rock,
                        Original_Location = _rock.Location,
                        New_Location = _newRookLoc
                    });

                    _rock.Location = _newRookLoc;
                }
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Metodo que donde se escribe la logica del juego
        /// </summary>
        /// <param name="gameTime">informacion de tiempo</param>
        protected override void Update(GameTime gameTime)
        {
            this.Pieces.ForEach(x => x.Position = Get_PiecePosition(x.Location));
            // Actualiza la posicion en pantalla de cada pieza segun su coordenada en el tablero

            lblPlayer.Text = $"Player { (CurrentPlayer.Equals(Player1) ? "1" : "2") }";

        }
        #endregion

        #region Draw
        /// <summary>
        /// Dibuja todos los sprites en pantalla
        /// </summary>
        /// <param name="drawHandler">controlador de dibujado</param>
        public override void Draw(DrawHandler drawHandler)
        {
            this.Board.Draw(drawHandler);
            this.Pieces.ForEach(x => x.Draw(drawHandler));
        }
        #endregion
    }
    public enum State
    {
        Normal,
        Check,
        Checkmate,
        Draw
    }
}
