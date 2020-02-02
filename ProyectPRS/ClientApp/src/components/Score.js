import React, { Component } from 'react';

export class Score extends Component {
    displayName = Score.name

    constructor(props) {
        super(props);
        this.state = { players: [], loading: true };
        debugger;
        fetch('/api/Players/GetPlayers')
            .then(response => response.json())
            .then(data => {
                this.setState({ players: data[0].json, loading: false });
            });
    }

    rendergamesTable(players) {
        let listPlayers = JSON.parse(players);
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Player</th>
                        <th>Won</th>
                        <th>Lost</th>                        
                    </tr>
                </thead>
                <tbody>
                    {listPlayers.map(player =>
                        <tr key={player.Id}>
                            <td>{player.Name}</td>
                            <td>{player.WonGames}</td>
                            <td>{player.LostGames}</td>                           
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.rendergamesTable(this.state.players);

        return (
            <div>
                <h1>Score</h1>
                <hr />
                {contents}
            </div>
        );
    }



}
