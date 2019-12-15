import React, { Component, Fragment } from 'react';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';
import CreatorRegistrationForm from './CreatorRegistrationForm';
class CreatorRegistrationModal extends Component {
    state = {
        modal: false
    }
    toggle = () => {
        this.setState(previous => ({
            modal: !previous.modal
        }));
    }
    render() {
        const isNew = this.props.isNew;
        let title = 'Edit Creator';
        let button = '';
        if (isNew) {
            title = 'Add Creator';
            button = <Button
                color="success"
                onClick={this.toggle}
                style={{ minWidth: "200px" }}>Add</Button>;
        } else {
            button = <Button
                color="warning"
                onClick={this.toggle}>Edit</Button>;
        }
        return <Fragment>
            {button}
            <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                <ModalHeader toggle={this.toggle}>{title}</ModalHeader>
                <ModalBody>
                    <CreatorRegistrationForm
                        addCreatorToState={this.props.addCreatorToState}
                        updateCreatorIntoState={this.props.updateCreatorIntoState}
                        toggle={this.toggle}
                        creator={this.props.creator} />
                </ModalBody>
            </Modal>
        </Fragment>;
    }
}
export default CreatorRegistrationModal;