import React, { Component } from 'react';
import FrequencyTable from './ReportFrequencyTable'

export class Report extends Component {
    displayName = Report.name

    constructor(props) {
        super(props);
        this.state = { wordsFrequencies: [], loading: true };

        fetch('api/frequencies')
            .then(response => response.json())
            .then(data => {
                this.setState({ wordsFrequencies: data, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FrequencyTable.renderWordFrequencyTable(this.state.wordsFrequencies);

        return (
            <div>
                <h1>Word Frequencies - Totals</h1>
                <p>This component demonstrates all totals fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}