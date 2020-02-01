import React, { Component } from 'react';

export class Score extends Component {
    displayName = Score.name

    constructor(props) {
        super(props);
        this.state = { games: [], loading: true };

        fetch('/api/Players/GetPlayers')
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
                        <th>Player</th>
                        <th>Won</th>
                        <th>Lost</th>
                        <th>#</th>
                    </tr>
                </thead>
                <tbody>
                    {listGames.map(game =>
                        <tr key={game.Player.Name}>
                            <td>{game.Won}</td>
                            <td>{game.Lost}</td>
                            <td><a href={"/Details?i=" + game.Player.Id}>Details</a></td>
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
                <hr />
                {contents}
            </div>
        );
    }



}
