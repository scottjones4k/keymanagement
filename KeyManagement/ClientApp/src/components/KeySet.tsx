import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as KeyStore from '../store/Keys';
import { KeySet } from '../models/Keys';

// At runtime, Redux will merge together...
type KeySetProps =
    KeyStore.KeyState // ... state we've requested from the Redux store
    & typeof KeyStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ page: string }>; // ... plus incoming routing parameters


class FetchData extends React.PureComponent<KeySetProps> {
    // This method is called when the component is first added to the document
    public componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    public componentDidUpdate() {
        this.ensureDataFetched();
    }

    public render() {
        return (
            <React.Fragment>
                <h1 id="tabelLabel">Key Sets</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                {this.renderKeySetTable()}
                {this.renderPagination()}
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        const page = parseInt(this.props.match.params.page, 10) || 1;
        this.props.requestKeySets(page);
    }

    private renderKeySetTable() {
        if (this.props.keySets) {
            return (
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {(this.props.keySets as KeySet[]).map((keyset: KeySet) =>
                            <tr key={keyset.id}>
                                <td>{keyset.id}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            );
        }
    }

    private renderPagination() {
        const prevPage = (this.props.page || 0) - 1;
        const nextPage = (this.props.page || 0) + 1;

        return (
            <div className="d-flex justify-content-between">
                <Link className='btn btn-outline-secondary btn-sm' to={`/keysets/${prevPage}`}>Previous</Link>
                {this.props.isLoading && <span>Loading...</span>}
                <Link className='btn btn-outline-secondary btn-sm' to={`/keysets/${nextPage}`}>Next</Link>
            </div>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.key, // Selects which state properties are merged into the component's props
    KeyStore.actionCreators // Selects which action creators are merged into the component's props
)(FetchData as any);
