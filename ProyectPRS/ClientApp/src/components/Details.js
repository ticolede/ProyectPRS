import React, { Component } from 'react';

export class Details extends Component {
    displayName = Details.name

    constructor(props) {
        super(props);
        this.state = { games: [], loading: true };

        let search = window.location.search;
        let params = new URLSearchParams(search);
        let p = params.get('i');

        fetch(`/api/Game/GetDetailScore?i=${p}`)
            .then(response => response.json())
            .then(data => {
                this.setState({ games: data[0].json, loading: false });
            });
    }

    rendergamesTable(games) {
        let listGames = JSON.parse(games);
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Date</th>
                        <th>Player One</th>
                        <th>Player Two</th>
                        <th>Rounds</th>
                        <th>Winner</th>
                    </tr>
                </thead>
                <tbody>
                    {listGames.map(game =>
                        <tr key={game.Id}>
                            <td>{game.Id}</td>
                            <td>{game.Date}</td>
                            <td>{game.PlayerOne.Name}</td>
                            <td>{game.PlayerTwo.Name}</td>
                            <td>{game.Rounds}</td>
                            <td>{game.Winner.Name}</td>
                            <td><hr /></td>
                            <td>
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Round</th>
                                            <th>Player One</th>
                                            <th>Player One Move</th>
                                            <th>Player Two</th>
                                            <th>Player Two Move</th>
                                            <th>Winner</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {game.Moves.map(Move =>
                                            <tr>
                                                <td>{Move.Round.RoundNumber}</td>
                                                <td>{Move.PlayerOne.Name}</td>
                                                <td>{Move.PlayerOneMove.Description}</td>
                                                <td>{Move.PlayerTwo.Name}</td>
                                                <td>{Move.PlayerTwoMove.Description}</td>
                                                <td>{Move.Round.Winner.Name}</td>
                                            </tr>
                                        )}
                                    </tbody>
                                </table>
                            </td>
                            <td><hr /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.rendergamesTable(this.state.moves);

        return (
            <div>
                <h1>Score</h1>
                {contents}
            </div>
        );
    }



}
