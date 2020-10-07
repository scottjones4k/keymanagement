import * as React from 'react';
import { connect } from 'react-redux';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as KeyStore from '../store/Keys';

type NewKeySetProps =
    RouteComponentProps<{ id: string }> // ... plus incoming routing parameters
    & typeof KeyStore.actionCreators // ... plus action creators we've requested

interface NewKeySetState {
    id?: string;
}

class NewKeySet extends React.Component<NewKeySetProps, NewKeySetState> {
    constructor(props: NewKeySetProps) {
        super(props);
        this.state = {
            id: undefined
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event: any) {
        const target = event.target;
        const value = target.name === 'isGoing' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        if (this.state.id === undefined) return;

        this.props.createKeySet(this.state.id);
    }

    public render() {
        return (
            <React.Fragment>
                <h1>Add New Key Set</h1>
                <Form onSubmit={this.handleSubmit}>
                    <FormGroup>
                        <Label for="id">Name</Label>
                        <Input type="text" id="id" name="id" value={this.state.id} onChange={this.handleInputChange} />
                    </FormGroup>
                    <Button type="submit">Save</Button>
                </Form>
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.key, // Selects which state properties are merged into the component's props
    KeyStore.actionCreators // Selects which action creators are merged into the component's props
)(NewKeySet as any);