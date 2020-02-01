import React, { Component } from 'react';

export class FetchData extends Component {      
    displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = { moves: [], loading: true };

        fetch('/api/Move/GetMoves')
            .then(response => response.json())
            .then(data => {
                this.setState({ moves: data[0].json, loading: false });
            });
    }
  
    rendermovesTable(moves) {     
        let listMoves = JSON.parse(moves);
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Move</th>
                        <th>Win</th>
                        <th>Lost</th>
                    </tr>
                </thead>
                <tbody>
                    {listMoves.map(move =>
                        <tr key={move.Id}>
                            <td>{move.Id}</td>
                            <td>{move.Description}</td>
                            <td>{move.LosedAgainst.Id}</td>
                            <td>{move.WinsAgainst.Id}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.rendermovesTable(this.state.moves);

        return (
            <div>
                <h1>Moves</h1>
                {contents}
            </div>
        );
    }



}
