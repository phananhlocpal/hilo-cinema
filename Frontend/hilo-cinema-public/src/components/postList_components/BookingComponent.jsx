import PropTypes from 'prop-types';
import Select from 'react-dropdown-select';

const BookingComponent = props => {
    return (
        <div className="card-body flex flex-col gap-3 px-3 py-4 bg-grey-110 rounded-b border border-grey-20">
            <Select
                options={props.options}
                labelField="name"
                valueField="id"
                onChange={(values) => this.setValues(values)}
                searchable={false} 
                placeholder="Chọn phim"
                
            />
            <Select
                options={props.options}
                labelField="name"
                valueField="id"
                onChange={(values) => this.setValues(values)}
                searchable={false} 
                placeholder="Chọn rạp"
                
            />
            <Select
                options={props.options}
                labelField="name"
                valueField="id"
                onChange={(values) => this.setValues(values)}
                searchable={false} 
                placeholder="Chọn ngày"
                
            />
        </div>
    );
};

BookingComponent.propTypes = {
    options:PropTypes.array,
};

export default BookingComponent;