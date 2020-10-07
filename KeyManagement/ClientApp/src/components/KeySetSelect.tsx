import * as React from 'react';
import { connect } from 'react-redux';
import { FormGroup, Label } from 'reactstrap';
import * as KeyStore from '../store/Keys';
import * as KeySet from '../store/Keys';
import { ApplicationState } from '../store';
import Select from 'react-select';
import _ from 'lodash';


interface InputProps {
    handleInputChange: (events: any[]) => void;
}

interface SelectValue {
    label: string,
    value: string
}

type KeySetProps =
    InputProps &
    KeyStore.KeyState &
    typeof KeyStore.actionCreators;

type State = {
    value?: SelectValue,
};

class KeySetSelect extends React.PureComponent<KeySetProps, State> {
    constructor(props: KeySetProps) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.handleSearch = _.throttle(this.handleSearch.bind(this), 1000, {
            trailing: true
        });
        this.filteredItems = this.filteredItems.bind(this);
        this.state = {
            value: undefined
        };
    }

    public componentDidMount() {
        this.props.searchKeySets('');
    }

    filteredItems() {
        return _.map(this.props.keySets, item => { return { label: item.id, value: item.id } });
    }

    handleSearch(inputValue: string) {
        this.props.searchKeySets(inputValue);
    }

    handleChange = (newValue: any, actionMeta: any) => {
        this.props.handleInputChange([
            { target: { name: 'keySetId', value: newValue && newValue.value } },
            { target: { name: 'keySetName', value: newValue && newValue.label } }
        ]);
        this.setState({ value: newValue });
    };

    public render() {
        return (
            <React.Fragment>
                <FormGroup>
                    <Label for="nappyType">Medicine</Label>
                    <Select
                        isClearable
                        isDisabled={this.props.isLoading}
                        isLoading={this.props.isLoading}
                        onChange={this.handleChange}
                        onInputChange={this.handleSearch}
                        options={this.filteredItems()}
                        value={this.state.value}
                    />
                </FormGroup>
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState, ownProps: InputProps) => ({ ...state.key, ...ownProps }),
    KeyStore.actionCreators
)(KeySetSelect as any);
