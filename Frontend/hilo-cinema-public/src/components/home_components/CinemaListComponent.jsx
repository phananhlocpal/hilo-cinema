import MovieCardItem from '../common_components/comom_item/MovieCardItem.jsx';
import { useSelector } from 'react-redux';
// eslint-disable-next-line react/prop-types
const CinemaListComponent = () => {
    const tabValue = useSelector((state) => state.home.tabValue);
    const recentMovieList = useSelector((state) => state.home.recentMovieList);
    const upcommingMovieList = useSelector((state) => state.home.upcommingMovieList);

    const selectedList = tabValue === 1 ? upcommingMovieList : recentMovieList;

    return (
        <div className='pt-5'>
            <div>
                <div className='grid grid-cols-2 sm:grid-cols-2 md:grid-cols-4 xl:grid-cols-4 gap-1 mb-10'>
                    {selectedList.map(({ id, title, img }) => (
                        <MovieCardItem
                            key={id}
                            title={title}
                            imageUrl={img}
                            widthCard="250px"
                            heightCard="500px"
                        />
                    ))}                        
                </div>
            </div>
        </div>
    );
};

export default CinemaListComponent;