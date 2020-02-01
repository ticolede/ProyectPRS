import React, { Component } from 'react';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);

        // eslint-disable-next-line
        this.state = { movesSelect: [], roundNumber: 1, roundMoves: [] };

        this.getMoves();
        this.onSubmit = this.onSubmit.bind(this);
        this.nextPlayer = this.nextPlayer.bind(this);
        this.finishRound = this.finishRound.bind(this);
    }

    getMoves() {
        fetch('/api/Move/GetMoves')
            .then(response => response.json())
            .then(data => {

                let parseJson = JSON.parse(data[0].json);
                this.setState({ movesSelect: parseJson });
            });
    }

    nextPlayer(e) {
        debugger;
        let idMove = this.firstMove.value;
        fetch(`/api/Move/NewMove?idGame=${this.state.game.IdGame}&idMove=${idMove}&idPlayer=${this.state.game.PlayerOne}&idRound=${this.state.game.IdRound}`)
            .then(response => response.json())
            .then(data => {
                debugger;
                let parseJson = JSON.parse(data[0].json);
                this.setState({ firstMove: parseJson });
                this.divFirstMove.style.display = "none";
                this.divSecondMove.style.display = "initial";
            });
    }

    finishRound(e) {
        debugger;
        let idMove = this.SecondMove.value;
        debugger;
        let index = this.firstMove.selectedIndex;
        let move = this.firstMove[index].text;
        let indextwo = this.SecondMove.selectedIndex;
        let movetwo = this.SecondMove[indextwo].text;

        fetch(`/api/Move/NewMove?idGame=${this.state.game.IdGame}&idMove=${idMove}&idPlayer=${this.state.game.PlayerTwo}&idRound=${this.state.game.IdRound}`)
            .then(response => response.json())
            .then(data => {

                let parseJson = JSON.parse(data[0].json);
                this.setState({ secondMove: parseJson });
                let winner = "";

                fetch(`/api/Game/CheckRound?idGame=${this.state.game.IdGame}&idRound=${this.state.game.IdRound}`)
                    .then(response => response.json())
                    .then(data => {

                        let parseJson = JSON.parse(data[0].json);
                        this.setState({ finishedRound: parseJson });
                        this.divSecondMove.style.display = "none";

                        if (parseJson.Winner === this.state.game.PlayerOne)
                            winner = this.state.p1;
                        else if (parseJson.Winner === -1)
                            winner = "DRAW";
                        else
                            winner = this.state.p2;

                        let moves = { IdRound: this.state.roundNumber, PlayerOne: this.state.p1, PlayerOneMove: move, PlayerTwo: this.state.p2, PlayerTwoMove: movetwo, Winner: winner };
                        this.state.roundMoves.push(moves);

                        if (parseJson.GameOver === 1) {
                            this.tableRound.style.display = "none";
                            this.setState({ roundNumber: 1, roundMoves: [] });
                            let action = window.confirm(`The winner is ${winner}!, Do you want to play again ?`)
                            if (action)
                                window.location.href = "/";
                            else
                                window.location.href = "https://www.google.com.uy";

                        }
                        else {
                            this.state.game.IdRound = parseJson.NextRound;
                            this.setState({ roundNumber: parseJson.NextRoundNumber });;
                            this.divFirstMove.style.display = "initial";
                            this.tableRound.style.display = "initial";
                        }
                    });

            });
    }

    onSubmit(e) {
        e.preventDefault();

        var playerOne = this.playerOne.value;
        var playerTwo = this.playerTwo.value;

        fetch(`/api/Game/StartGame?playerOne=${playerOne}&playerTwo=${playerTwo}`)
            .then(response => response.json())
            .then(data => {
                debugger;
                let parseJson = JSON.parse(data[0].json);
                this.setState({ game: parseJson, loading: false, p1: playerOne, p2: playerTwo });
                this.divHome.style.display = "none";
                this.divFirstMove.style.display = "initial";
            });
    }

    renderSelectFirstMove(moves) {
        return (
            <select name="firstMove" ref={(c) => this.firstMove = c}>

                {moves.map(move =>
                    <option value={move.Id}>{move.Description}</option>
                )}
            </select>
        );
    }

    renderTableRound(roundMoves) {
        return (
            <table class="table table-responsive">
                <thead>
                    <tr>
                        <th>
                            Round number
                    </th>
                        <th>
                            Player one
                    </th>
                        <th>
                            Player one move
                    </th>
                        <th>
                            Player two
                    </th>
                        <th>
                            Player two move
                    </th>
                        <th>
                            Winner
                    </th>
                    </tr>
                </thead>
                <tbody>
                    {roundMoves.map(moves =>
                        <tr key={moves.IdRound}>
                            <td>{moves.IdRound}</td>
                            <td>{moves.PlayerOne}</td>
                            <td>{moves.PlayerOneMove}</td>
                            <td>{moves.PlayerTwo}</td>
                            <td>{moves.PlayerTwoMove}</td>
                            <td>{moves.Winner}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    renderSelectSecondMove(moves) {
        return (
            <select name="SecondMove" ref={(c) => this.SecondMove = c}>

                {moves.map(move =>
                    <option key={move.Id} value={move.Id}>{move.Description}</option>
                )}
            </select>
        );
    }

    render() {
        let selectFirst = this.renderSelectFirstMove(this.state.movesSelect);
        let selectSecond = this.renderSelectSecondMove(this.state.movesSelect);
        let renderTableRounds = this.renderTableRound(this.state.roundMoves);
        return (
            <div>
                <div ref={(c) => this.divHome = c} name="divHome">
                    <h1 style={{ textAlign: 'center' }}>Enter player´s name!</h1>
                    <hr />
                    <form className="form-horizontal">
                        <input type="text" style={{ textAlign: 'center', margin: '5px' }} className="form-control" ref={(c) => this.playerOne = c} placeholder="Player one" name="playerOne" />
                        <input type="text" style={{ textAlign: 'center', margin: '5px' }} className="form-control" ref={(c) => this.playerTwo = c} placeholder="Player two" name="playerTwo" />
                    </form>

                    <button type="button" style={{ textAlign: 'center', marginTop: '20px' }} onClick={this.onSubmit} className="btn btn-success btn-block">Play!</button>
                </div>

                <div style={{ display: 'none' }} ref={(c) => this.divFirstMove = c} name="divFirstMove">
                    <h1 style={{ textAlign: 'center' }}>Player one</h1>
                    <form className="form-horizontal">
                        Choose your move:
                        {selectFirst}
                    </form>
                    <button type="button" style={{ textAlign: 'center', marginTop: '20px' }} onClick={this.nextPlayer} className="btn btn-success btn-block">Next player</button>
                </div>
                <div style={{ display: 'none' }} ref={(c) => this.divSecondMove = c} name="divSecondMove">
                    <h1 style={{ textAlign: 'center' }}>Player two</h1>
                    <form className="form-horizontal">
                        Choose your move:
                    {selectSecond}
                    </form>
                    <button type="button" style={{ textAlign: 'center', marginTop: '20px' }} onClick={this.finishRound} className="btn btn-success btn-block">Finish round</button>
                </div>
                <hr />
                <div style={{ display: 'none' }} ref={(c) => this.tableRound = c} name="tableRound">
                    {renderTableRounds}
                </div>
            </div>
        );
    }
}
