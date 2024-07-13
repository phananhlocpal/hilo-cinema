import Header from './Header.jsx';
import Footer from './Footer.jsx';
import { Outlet } from 'react-router-dom';

const BasicLayout = () => {
    return (
        <div className='relative'>
            <Header />
            <div className="line-default block" style={{ borderBottom: '6px solid #f4f4f4', transform: 'matrix(1, 0, 0, -1, 0, 0)' }}></div>
            <Outlet />
            <Footer />
        </div>
    );
};

export default BasicLayout;
