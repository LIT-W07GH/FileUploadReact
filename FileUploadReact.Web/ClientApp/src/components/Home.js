import React, { Component } from 'react';
import axios from 'axios';

const toBase64 = file => new Promise((resolve, reject) => {
  const reader = new FileReader();
  reader.readAsDataURL(file);
  reader.onload = () => resolve(reader.result);
  reader.onerror = error => reject(error);
});

export class Home extends Component {

  descriptionRef = React.createRef();
  fileInputRef = React.createRef();

  state = {
    description: '',
    images: []
  }


  componentDidMount = async () => {
    this.descriptionRef.current.focus();
    this.refreshImages();
  }
  onDescriptionChange = e => {
    this.setState({ description: e.target.value });
  }

  refreshImages = async () => {
    const { data } = await axios.get('/api/upload/getall');
    this.setState({ images: data });
  }

  onUpload = async () => {
    const file = this.fileInputRef.current.files[0];
    const fileName = file.name;
    const base64File = await toBase64(file);
    const { description } = this.state;
    await axios.post('/api/upload/addimage', { description, base64File, fileName });
    this.setState({ description: '' });
    this.fileInputRef.current.value = '';
    this.refreshImages();
  }

  render() {
    return (
      <div className="row">
        <div className="col-md-6 col-md-offset-3 well">
          <input ref={this.descriptionRef} onChange={this.onDescriptionChange} value={this.state.description} className="form-control" type="text" name="description" placeholder="Description" />
          <br />
          <input ref={this.fileInputRef} type="file" name="image" className="form-control" />
          <br />
          <button onClick={this.onUpload} className="btn btn-primary">Upload</button>

          <table className="table table-bordered">
            <thead>
              <tr>
                <th>Image</th>
                <th>Description</th>
              </tr>
            </thead>
            <tbody>
              {this.state.images.map(i => <tr key={i.id}>
                <td>
                  <img src={`/images/getimage?filename=${i.fileName}`} style={{ width: 200 }} />
                </td>
                <td>
                  {i.description}
                </td>
              </tr>)}
            </tbody>
          </table>
        </div>
      </div>
    );
  }
}
