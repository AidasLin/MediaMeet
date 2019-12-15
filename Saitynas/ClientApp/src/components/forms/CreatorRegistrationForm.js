import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { CREATORS_API_URL } from '../../constants';
class CreatorRegistrationForm extends React.Component {
    state = {
        creatorId: 0,
        name: '',
        pseudonym: '',
        city: '',
        department: ''
    }
    
    componentDidMount() {
        if (this.props.creator) {
            const { creatorId, name, pseudonym, city, department } = this.props.creator
            this.setState({ creatorId, name, pseudonym, city, department });
        }
    }
    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }
    submitNew = e => {
        e.preventDefault();
        fetch(`${CREATORS_API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                pseudonym: this.state.pseudonym,
                city: this.state.city,
                department: this.state.department
            })
        })
            .then(res => res.json())
            .then(creator => {
                this.props.addCreatorToState(creator);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }
    submitEdit = e => {
        e.preventDefault();
        fetch(`${CREATORS_API_URL}/${this.state.creatorId}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                creatorId: this.state.creatorId,
                name: this.state.name,
                pseudonym: this.state.pseudonym,
                city: this.state.city,
                department: this.state.department
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateCreatorIntoState(this.state.creatorId);
            })
            .catch(err => console.log(err));
    }
    render() {
        return <Form onSubmit={this.props.creator ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="name">Name:</Label>
                <Input type="text" name="name" onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name} />
            </FormGroup>
            <FormGroup>
                <Label for="pseudonym">Pseudonym:</Label>
                <Input type="text" name="pseudonym" onChange={this.onChange} value={this.state.pseudonym === null ? '' : this.state.pseudonym} />
            </FormGroup>
            <FormGroup>
                <Label for="city">City:</Label>
                <Input type="text" name="city" onChange={this.onChange} value={this.state.city === null ? '' : this.state.city} />
            </FormGroup>
            <FormGroup>
                <Label for="department">Department:</Label>
                <Input type="text" name="department" onChange={this.onChange} value={this.state.department === null ? '' : this.state.department}
                    placeholder="Films/Photo/etc" />
            </FormGroup>
            <Button>Send</Button>
        </Form>;
    }
}
export default CreatorRegistrationForm;