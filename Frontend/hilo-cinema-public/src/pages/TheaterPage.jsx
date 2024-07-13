import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchTheaters } from '../redux/actions/theaterAction';

const TheaterPage = () => {
    const dispatch = useDispatch();
    
    useEffect(() => {
        dispatch(fetchTheaters());
    }, [dispatch]);
    
    const theaters = useSelector(state => state.theater.theaters);
    // const loading = useSelector(state => state.theater.loading);
    // const error = useSelector(state => state.theater.error);

    console.log(theaters);

    // if (loading) {
    //     return <div>Loading...</div>;
    // }

    // if (error) {
    //     return <div>Error: {error.message}</div>;
    // }

    return (
        <div>
            <h1>Theater List</h1>
            <ul>
                {theaters.map(theater => (
                    <li key={theater.id}>{theater.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default TheaterPage;
