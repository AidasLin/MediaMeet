import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import CreatorTable from './CreatorTable';
import CreatorRegistrationModal from './forms/CreatorRegistrationModal';
import { CREATORS_API_URL } from '../constants';
class Creators extends Component {
    state = {
        items: []
    }
    componentDidMount() {
        this.getItens();
    }
    getItens = () => {
        fetch(CREATORS_API_URL)
            .then(res => res.json())
            .then(res => this.setState({ items: res }))
            .catch(err => console.log(err));
    }
    addCreatorToState = creator => {
        this.setState(previous => ({
            items: [...previous.items, creator]
        }));
    }
    updateState = (creatorId) => {
        this.getItens();
    }
    deleteItemFromState = creatorId => {
        const updated = this.state.items.filter(item => item.creatorId !== creatorId);
        this.setState({ items: updated })
    }
    render() {
        return <Container style={{ paddingTop: "100px" }}>
            <Row>
                <Col>
                    <CreatorTable
                        items={this.state.items}
                        updateState={this.updateState}
                        deleteItemFromState={this.deleteItemFromState} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <CreatorRegistrationModal isNew={true} addCreatorToState={this.addCreatorToState} />
                </Col>
            </Row>
        </Container>;
    }
} 
export default Creators;