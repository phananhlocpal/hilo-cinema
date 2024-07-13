import { exampleMovie } from "../../../data_example";
import CinemaScheduleLine from "./CinemaScheduleLine";
import PropTypes from 'prop-types';
const Schedule = ({ data }) => {
    return (
        <div className="showtime__list">
            {data.map((theater, index) => (
                <div key={index} className="showtime__cinema md:py-8 py-4 px-3 odd:bg-white even:bg-[#FDFBFA] even:border-t even:border-b">
                    <h1 className="text-base font-bold mb-4">{theater.theater}</h1>
                    {theater.schedules.map((detailSchedule, idx) => (
                        <CinemaScheduleLine key={idx} cinemaData={exampleMovie} label={detailSchedule.type} times={detailSchedule.times} />
                    ))}
                </div>
            ))}
        </div>
    );
};

Schedule.propTypes = {
    data:PropTypes.array,
}

export default Schedule;
