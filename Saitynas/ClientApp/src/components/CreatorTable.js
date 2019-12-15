import React, { Component } from 'react';
import { Table, Button } from 'reactstrap';
import CreatorRegistrationModal from './forms/CreatorRegistrationModal';
import { CREATORS_API_URL } from '../constants';
class CreatorTable extends Component {
    deleteItem = creatorId => {
        let confirmDeletion = window.confirm('Do you really wish to delete it?');
        if (confirmDeletion) {
            fetch(`${CREATORS_API_URL}/${creatorId}`, {
                method: 'delete',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(res => {
                    this.props.deleteItemFromState(creatorId);
                })
                .catch(err => console.log(err));
        }
    }
    render() {
        const items = this.props.items;
        return <Table striped>
            <thead className="thead-dark">
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Pseudonym</th>
                    <th>City</th>
                    <th>Department</th>
                    <th style={{ textAlign: "center" }}>Actions</th>
                </tr>
            </thead>
            <tbody>
                {!items || items.length <= 0 ?
                    <tr>
                        <td colSpan="6" align="center"><b>No creators yet</b></td>
                    </tr>
                    : items.map(item => (
                        <tr key={item.creatorId}>
                            <th>
                                {item.creatorId}
                            </th>
                            <td>
                                {item.name}
                            </td>
                            <td>
                                {item.pseudonym}
                            </td>
                            <td>
                                {item.city}
                            </td>
                            <td>
                                {item.department}
                            </td>
                            <td align="center">
                                <div>
                                    <CreatorRegistrationModal
                                        isNew={false}
                                        creator={item}
                                        updateCreatorIntoState={this.props.updateState} />
                                    &nbsp;&nbsp;&nbsp;
                  <Button color="danger" onClick={() => this.deleteItem(item.creatorId)}>Delete</Button>
                                </div>
                            </td>
                        </tr>
                    ))}
            </tbody>
        </Table>;
    }
}
export default CreatorTable;