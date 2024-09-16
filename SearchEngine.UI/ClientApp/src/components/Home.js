import React, { Component, useState } from 'react';

// Functional SearchBar component
const SearchBar = ({ onSearch }) => {
    const [query, setQuery] = useState('');

    const handleSearch = () => {
        onSearch(query);
    };

    return (
        <div style={{ marginBottom: '20px' }}>
            <input
                type="text"
                value={query}
                onChange={(e) => setQuery(e.target.value)}
                placeholder="Search..."
                style={{ padding: '10px', width: '300px' }}
            />
            <button onClick={handleSearch} style={{ padding: '10px 20px', marginLeft: '10px' }}>
                Search
            </button>
        </div>
    );
};


const SearchResults = ({ results }) => {
    return (
        <div>
            {results.length === 0 ? (
                <p>No results found.</p>
            ) : (
                <ul>
                    {results.map((result, index) => (
                        <li key={index}>{result}</li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default SearchResults;


export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            result: [],
            loading: false,
            searchPerformed: false // Tracks if a search has been performed
        };
    }

    handleSearch = async (query) => {
        this.setState({ loading: true, searchPerformed: true });
        
        try {
            console.log('Searching for:', query);
            const response = await fetch(`weatherforecast/search?query=${query}`);
            const data = await response.json();
            this.setState({ result: data, loading: false });
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
            this.setState({ result: [], loading: false });
        }
    };

    render() {
        const { result, loading, searchPerformed } = this.state;
        return (
            <div>
                <h1>Looking for something 👀 ?</h1>
                <SearchBar onSearch={this.handleSearch} />
                {loading && <p>Loading...</p> }


                {!loading && searchPerformed && result.length === 0 && (
                    <p>No results found.</p>
                )}

                {!loading && result.length > 0 && (
                    <SearchResults results={result} />
                )}
            </div>
        );
    }
}
